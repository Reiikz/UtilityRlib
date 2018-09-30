using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityRlib.NumericHelpers;
using UtilityRlib.StringHelper.TextStringHelper;
using UtilityRlib.CollectionHelpers;

namespace UtilityRlib.AutoGridLayout
{
    public class GridLayout
    {
        public Grid<Cell> grid { get; private set; }
        private string Arrangement;
        public IntVector2 Space { get; }
        public IntVector4 Offsets { get; set; }

        public GridLayout(string CellsArrangement, string Spaceoffsets, int spaceX, int spaceY)
        {
            Space = new IntVector2(spaceX, spaceY);
            CellsArrangement = Arrangement;
            Offsets = Get4(Spaceoffsets);
            RegenerateLayout();
        }

        public void RegenerateLayout()
        {
            string[] lines = Arrangement.Explode(" -- ");
            
        }

        private IntVector4 Get4(string s)
        {
            int t, b, l, r;
            if (s.Contains("top"))
            {
                t = NumericParser.getIntByDelimiters(s, "top", ';');
            }
            else
            {
                t = 0;
            }
            if (s.Contains("bottom"))
            {
                b = NumericParser.getIntByDelimiters(s, "bottom", ';');
            }
            else
            {
                b = 0;
            }
            if (s.Contains("left"))
            {
                l = NumericParser.getIntByDelimiters(s, "left", ';');
            }
            else
            {
                l = 0;
            }
            if (s.Contains("right"))
            {
                r = NumericParser.getIntByDelimiters(s, "right", ';');
            }
            else
            {
                r = 0;
            }
            return new IntVector4(t, b, l, r);
        }

        /*
        public void GenerateGrid()
        {
            string[] columns = inputColumns.Split(' ');
            string[] rows = inputRows.Split(' ');
            List<Cell> cellColumns = new List<Cell>();
            List<Cell> cellRows = new List<Cell>();

            //get x available space
            IntVector2 ASpace = space;
            ASpace = ASpace.RestForece(margins.ToVector2Sum());
            foreach (string item in columns)
            {
                if (item.Contains("fr"))
                {
                    cellColumns.Add(Cell.GetCell());
                    continue;
                }
                IntVector2 cellX = new IntVector2(NumericParser.getInt(item), 0);
                ASpace = ASpace.RestForece(cellX);
                cellColumns.Add(new Cell(cellX, IntVector2.GetEmptyVec()));
            }

            int xStep = 0;
            if (ASpace.X != 0)
                xStep = ASpace.X / CollectionHelper.CountOf(columns, "fr");

            for (int i = 0; i < columns.Length; i++)
            {
                if (columns[i].Contains("fr"))
                {
                    cellColumns.ElementAt(i).Size = cellColumns.ElementAt(i).Size.AddForce(new IntVector2(xStep, 0));
                }
            }

            foreach (string item in rows)
            {
                if (item.Contains("fr"))
                {
                    cellRows.Add(Cell.GetCell());
                    continue;
                }
                IntVector2 cellY = new IntVector2(0, NumericParser.getInt(item));
                ASpace = ASpace.RestForece(cellY);
                cellRows.Add(new Cell(cellY, IntVector2.GetEmptyVec()));
            }

            int yStep = 0;
            if (ASpace.Y != 0)
                yStep = ASpace.Y / CollectionHelper.CountOf(rows, "fr");

            for (int i = 0; i < rows.Length; i++)
            {
                if (rows[i].Contains("fr"))
                {
                    cellRows.ElementAt(i).Size = cellRows.ElementAt(i).Size.AddForce(new IntVector2(0, yStep));
                }
            }

            grid = new List<List<Cell>>();
            int max;
            if (cellColumns.Count < cellRows.Count) max = cellColumns.Count; else max = cellRows.Count;
            for (int i = 0; i < max; i++)
            {
                List<Cell> temp = new List<Cell>();
                for (int j = 0; j < max; j++)
                {
                    Cell tempCell1, tempCell2;
                    tempCell1 = cellRows.ElementAt(j);
                    tempCell2 = cellColumns.ElementAt(j);
                    temp.Add(tempCell1.SumCells(tempCell2));
                }
                grid.Add(temp);
            }
        }
        */

    }
}
