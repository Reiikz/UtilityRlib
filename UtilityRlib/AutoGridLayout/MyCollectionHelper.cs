using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityRlib.NumericHelpers;
using UtilityRlib.CollectionHelpers;

namespace UtilityRlib.AutoGridLayout
{
    class MyCollectionHelper : CollectionHelper
    {
        public static IntVector2 sumCellsSizes(List<Cell> cells)
        {
            int y, x;
            x = sumAllInt(CellListToIntArray(cells, "cell to xSizes"));
            y = sumAllInt(CellListToIntArray(cells, "cell to ySizes"));
            return new IntVector2(x, y);
        }

        public static int[] CellListToIntArray(List<Cell> cells, string s)
        {
            int[] output = new int[cells.Count];
            Cell[] c = cells.ToArray();
            if(s.Equals("cell to xSizes"))
                for(int i = 0; i < cells.Count; i++)
                {
                    output[i] = c[i].Size.X;
                }
            if(s.Equals("cell to ySizes"))
                for(int i = 0;i < cells.Count; i++)
                {
                    output[i] = c[i].Size.Y;
                }
            return output;
        }
    }
}
