using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SHKEntity;

namespace StrongholdTiming.Models
{
    public class VillageModel
    {
        public int Id { get; set;  }
        public string Name { get; set; }
        //public string Owner { get; set; }
        public string Parish { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        public VillageModel() { }

        public VillageModel(Village v)
        {
            Id = v.Id;
            Name = v.Name;
            //Owner = v.OwnerId;
            Parish = v.Parish;
            X = v.Position.X;
            Y = v.Position.Y;
        }

        internal Village GetEntity()
        {
            Village v = new Village(Name, Parish, 0);
            v.Id = Id;
            v.Position.X = X;
            v.Position.Y = Y;
            return v;
        }
    }
}