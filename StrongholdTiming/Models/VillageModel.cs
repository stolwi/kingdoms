using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SHKEntity;

namespace StrongholdTiming.Models
{
    public class VillageModel
    {
        public int id { get; set;  }
        public string name { get; set; }
        //public string Owner { get; set; }
        public string parish { get; set; }
        public double x { get; set; }
        public double y { get; set; }

        public VillageModel() { }

        public VillageModel(Village v)
        {
            id = v.Id;
            name = v.Name;
            //Owner = v.OwnerId;
            x = v.Position.X;
            y = v.Position.Y;
        }

        internal Village GetEntity()
        {
            Village v = new Village { Name = name, Confidence = 0 };
            v.Id = id;
            v.Position = new Location(x, y);
            return v;
        }
    }
}