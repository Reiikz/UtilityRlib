using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityRlib.NumericHelpers;

namespace UtilityRlib.AutoGridLayout
{
    public class Cell
    {
        public IntVector2 Size { get; set; }
        public IntVector2 Margins { get; set; }
        public IntVector2 Location { get; set; }

        public Cell() : this(new IntVector2(), new IntVector2()) { }

        public Cell(IntVector2 CellSize, IntVector2 CellLocation)
        {
            Size = CellSize;
            Location = CellLocation;
        }

        override public string ToString()
        {
            return "Location: " + Location.ToString() + " Size: " + Size.ToString();
        }
    }
}
