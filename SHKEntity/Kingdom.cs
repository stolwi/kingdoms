using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SHKEntity
{
    public class Kingdom
    {
        private int Id;
        private DataClasses1DataContext db;

        public Kingdom(int id)
        {
            Id = id;
            db = new DataClasses1DataContext();
        }

        public IQueryable<Village> Villages {
            get 
            {
                return db.Villages; 
            } 
        }

        public Village GetVillage(int id)
        {
            var village = from v in db.Villages
                          where v.Id == id
                          select v;
            return village.FirstOrDefault();
        }

        public Village GetVillageByName(string name)
        {
            var village = from v in db.Villages
                          where v.Name == name
                          select v;
            return village.FirstOrDefault();
        }

        public int AddVillage(Village v)
        {
            // Right now, only allow unique names
            // TODO expand this to allow same-names, but then figure out how to know when they really are the same.
            Village existing = GetVillage(v.Id);
            if (existing == null)
            {
                existing = db.Villages.Where(x => x.Name == v.Name).FirstOrDefault();
            }

            if (existing != null)
            {
                return existing.Id;
            }
            if (v.WorldId == 0) v.WorldId = 1;
            db.Villages.InsertOnSubmit(v);
            db.SubmitChanges();
            return v.Id;
        }

        public int AddEdge(Edge e)
        {
            if (db.Edges.Any(x => x.FromVillageId == e.FromVillageId && x.ToVillageId == e.ToVillageId))
            {
                // For now silently skip adding this duplicate edge
                return 0;
            }
            if (!db.Villages.Any(x => x.Id == e.FromVillageId))
            {
                throw new Exception("Edge.FromVillageId " + e.FromVillageId + " doesn't reference existing village");
            }
            if (!db.Villages.Any(x => x.Id == e.ToVillageId))
            {
                throw new Exception("Edge.ToVillageId " + e.ToVillageId + " doesn't reference existing village");
            }
            if (e.Time <= 0)
            {
                throw new Exception("Edge time is not a positive number");
            }
            // TODO - validate time type
            db.Edges.InsertOnSubmit(e);
            db.SubmitChanges();
            return e.Id;
        }

        public bool IsConfidentVillage(int id)
        {
            Village target = db.Villages.Where(x => x.Id == id).FirstOrDefault();
            return (target != null && target.Confidence > 29);
        }

        internal class EdgeVillageConfidence
        {
            internal Edge E { get; set; }
            internal Village Villa { get; set; }

            public EdgeVillageConfidence(Edge ee, Village v)
            {
                E = ee;
                Villa = v;
            }
        }

        public void FixVillageLocation(int id)
        {
            Village target = db.Villages.Where(x => x.Id == id).FirstOrDefault();
            List<Edge> foundEdges = db.Edges.Where(x => (x.FromVillageId == id && IsConfidentVillage(x.ToVillageId)) ||
                                                     (x.ToVillageId == id && IsConfidentVillage(x.FromVillageId))).ToList();

            if (foundEdges.Count < 3)
            {
                throw new Exception("Failed to find at least 3 edges to confident villages");
            }
            // Assign each edge with the confidence associated with the other related village
            var edgesWithConfidences = new List<EdgeVillageConfidence>();
            foreach(Edge e in foundEdges)
            {
                int otherVillageId = (e.FromVillageId == id) ? e.ToVillageId : e.FromVillageId;
                Village otherVillage = db.Villages.Where(x => x.Id == otherVillageId).FirstOrDefault(); 
                edgesWithConfidences.Add(new EdgeVillageConfidence(e, otherVillage));
            }
            // Now use most confident 3 villages for the calculation
            List<EdgeVillageConfidence> bestEdges = edgesWithConfidences.OrderByDescending(x => x.Villa.Confidence).Take(3).ToList();

            EdgeVillageConfidence e1 = bestEdges[0];
            EdgeVillageConfidence e2 = bestEdges[1];
            EdgeVillageConfidence e3 = bestEdges[2];
            Location pos4 = MathLogic.Trilaterate(e1.Villa.Position, e2.Villa.Position, e3.Villa.Position, e1.E.Time, e2.E.Time, e3.E.Time);

            target.Position = pos4;
        }
        public double DistanceBetweenVillageIds(int id1, int id2)
        {
            Village v1 = db.Villages.Where(x => x.Id == id1).FirstOrDefault();
            if (v1 == null)
            {
                throw new Exception("Failed to find village with id: " + id1);
            }
            Village v2 = db.Villages.Where(x => x.Id == id2).FirstOrDefault();
            if (v2 == null)
            {
                throw new Exception("Failed to find village with id: " + id2);
            }
            return DistanceBetween(v1, v2);
        }

        public double DistanceBetween(Village v1, Village v2)
        {
            if (v1.Confidence <= 0)
            {
                throw new Exception("Distance failure: Village 1 has a zero-confidence position");
            }
            if (v2.Confidence <= 0)
            {
                throw new Exception("Distance failure: Village 2 has a zero-confidence position");
            }
            return DistanceBetween(v1.Position, v2.Position);
        }

        public double DistanceBetween(Location l1, Location l2)
        {
            double dx = l2.X - l1.X;
            double dy = l2.Y - l1.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }


        public void UpdateDB()
        {
            db.SubmitChanges();
        }

        public void RemoveVillage(int id)
        {
            Village v = GetVillage(id);
            RemoveAllEdgesFor(v);
            db.Villages.DeleteOnSubmit(v);
            db.SubmitChanges();
        }

        private void RemoveAllEdgesFor(Village v)
        {
            db.Edges.DeleteAllOnSubmit(db.Edges.Where(x => (x.FromVillageId == v.Id || x.ToVillageId == v.Id)));
        }
    }
}
