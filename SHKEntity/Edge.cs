using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SHKEntityOld
{
    public class Edge
    {
        public int Id { get; set; }
        public int FromId { get; set; }
        public int ToId { get; set; }
        public int Time { get; set; }
        public string TimeType { get; set; }

        public Edge(int from, int to, int time, string type)
        {
            FromId = from;
            ToId = to;
            Time = time;
            TimeType = type;
        }
    }
}
