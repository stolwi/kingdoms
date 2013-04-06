using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SHKEntity
{
    public class Kingdom
    {
        private int Id;
        private List<Village> villages = new List<Village>();
        private List<Edge> edges = new List<Edge>();
        private int maxVillageId = 0;
        private int maxEdgeId = 0;

        public Kingdom(int id)
        {
            Id = id;
        }

        public List<Village> Villages { get { return villages; } }

        public Village GetVillage(int id)
        {
            return villages.Find(x => x.Id == id);
        }

        public int AddVillage(Village v)
        {
            // Right now, only allow unique names
            // TODO expand this to allow same-names, but then figure out how to know when they really are the same.
            Village existing = villages.Find(x => x.Name.Equals(v.Name));

            if (existing != null)
            {
                return existing.Id;
            }
            maxVillageId++;
            v.Id = maxVillageId;
            villages.Add(v);
            return maxVillageId;
        }

        public int AddEdge(Edge e)
        {
            if (!villages.Any(x => x.Id == e.FromId))
            {
                throw new Exception("Edge.FromId " + e.FromId + " doesn't reference existing village");
            }
            if (!villages.Any(x => x.Id == e.ToId))
            {
                throw new Exception("Edge.ToId " + e.ToId + " doesn't reference existing village");
            }
            if (e.Time <= 0)
            {
                throw new Exception("Edge time is not a positive number");
            }
            // TODO - validate time type
            maxEdgeId++;
            e.Id = maxEdgeId;
            edges.Add(e);
            return maxEdgeId;
        }

        public bool IsConfidentVillage(int id)
        {
            Village target = villages.Find(x => x.Id == id);
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
            Village target = villages.Find(x => x.Id == id);
            List<Edge> foundEdges = edges.Where(x => (x.FromId == id && IsConfidentVillage(x.ToId)) ||
                                                     (x.ToId == id && IsConfidentVillage(x.FromId))).ToList();

            if (foundEdges.Count < 3)
            {
                throw new Exception("Failed to find at least 3 edges to confident villages");
            }
            // Assign each edge with the confidence associated with the other related village
            var edgesWithConfidences = new List<EdgeVillageConfidence>();
            foreach(Edge e in foundEdges)
            {
                int otherVillageId = (e.FromId == id) ? e.ToId : e.FromId;
                Village otherVillage = villages.Find(x => x.Id == otherVillageId);
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
            Village v1 = villages.Find(x => x.Id == id1);
            if (v1 == null)
            {
                throw new Exception("Failed to find village with id: " + id1);
            }
            Village v2 = villages.Find(x => x.Id == id2);
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

    }
}
