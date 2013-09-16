using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SHKEntity
{
    partial class Village
    {
        public Location Position { 
            get { return new Location(_PosX, _PosY); }
            set { _PosX = value.X; _PosY = value.Y; }
        }
    }

}
