using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SHKEntity;

namespace StrongholdTiming.Models
{
    public class EdgeModel
    {
        int StartVillageId { get; set; }
        int EndVillageId { get; set; }
        double DistanceInSeconds { get; set; }
        string DistanceMeasurementType { get; set; }

        public EdgeModel(Edge e)
        {
            StartVillageId = e.FromVillageId;
            EndVillageId = e.ToVillageId;
            DistanceInSeconds = e.Time;
            DistanceMeasurementType = e.TimeType;
        }

        internal Edge GetEntity()
        {
            return new Edge { FromVillageId = StartVillageId, ToVillageId = EndVillageId, Time = DistanceInSeconds, TimeType = DistanceMeasurementType };
        }
    }
}