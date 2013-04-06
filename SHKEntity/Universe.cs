using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SHKEntity
{
    public class Universe
    {
        private static Kingdom[] kingdoms = new Kingdom[10];

        public static Kingdom GetKingdom(int worldId)
        {
            if (kingdoms[worldId] == null)
            {
                CreateKingdom(worldId);
            }
            return kingdoms[worldId];
        }

        public static void CreateKingdom(int worldId)
        {
            if (kingdoms[worldId] != null)
            {
                throw new Exception("Kingdom " + worldId + " already exists!");
            }
            kingdoms[worldId] = new Kingdom(worldId);
        }
    }
}
