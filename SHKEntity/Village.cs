using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SHKEntityOld
{
    public class Village
    {
        public int Id { get; set; }
        public Location Position { get; set; }
        public int Confidence { get; set; }
        public string Name { get; set; }
        public string Parish { get; set; }
        public int OwnerId { get; set; }

        public Village(string name)
        {
            Position = new Location(0, 0);
            Name = name;
        }

        public Village(string name, string parish = "", int ownerId = 0)
        {
            Position = new Location(0, 0);
            Name = name;
            Parish = parish;
            OwnerId = ownerId;
        }

    }
}
