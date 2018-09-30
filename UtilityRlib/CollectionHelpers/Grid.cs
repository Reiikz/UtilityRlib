using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityRlib.CollectionHelpers
{
    public class Grid<T>
    {
        public T[][] Data { get; private set; }
        public int Rows { get; private set; }
        public int Columns { get; private set; }
        public int Mode { get; private set; }
        private int iStepping;
        private int actualWriteRow;
        private int actualWriteColumn;
        private int actualReadRow;
        private int actualReadColumn;

        public Grid() : this(10, 10, 0) { }

        public Grid(int rows, int columns) : this(rows, columns, 0) {}

        public Grid(int rows, int columns, int mode) : this(rows, columns, 10, mode) { }

        public Grid(int rows, int columns, int Stepping, int ExpansionMode)
        {
            Columns = columns;
            Rows = rows;
            Data = new T[Rows][];
            for (int i = 0; i < Data.Length; i++)
            {
                Data[i] = new T[Columns];
            }
            iStepping = Stepping;
            actualReadRow = 0;
            actualReadColumn = 0;
            actualWriteColumn = 0;
            actualWriteRow = 0;
            if(ExpansionMode != 0)
            {
                throw new Exception("Invalid Mode: " + ExpansionMode);
            }
            Mode = ExpansionMode;
        }

        public T Next()
        {
            actualReadColumn++;
            if(actualReadColumn >= Columns)
            {
                actualReadColumn = 0;
                actualReadRow++;
            }
            if (actualReadRow >= Rows)
                actualReadRow = 0;
            return Data[actualReadRow][actualReadColumn];
        }

        public bool IsNext()
        {
            int tempColumn = 0;
            if (actualReadColumn >= Columns)
                tempColumn = actualReadColumn + 1;
            if (actualReadRow >= Rows && tempColumn >= actualReadColumn)
                return false;
            return true;
        }

        public void Add(T o)
        {
            actualWriteColumn++;
            if(actualWriteColumn >= Columns)
            {
                actualWriteColumn = 0;
                actualWriteRow++;
            }
            if(actualWriteRow >= Rows)
            {
                ExtendGrid();
            }
        }

        private void ExtendGrid()
        {
            switch(Mode)
            {
                case 0:
                    {
                        ExpandByStep();
                        break;
                    }
                default:
                    {
                        throw new Exception("Unkown exception: Mode is out of range");
                    }
            }
        }

        public void ExpandByStep(int step)
        {
            T[][] temp = Data;
            Rows += step;
            Columns += step;
            Data = new T[Rows][];
            for(int i = 0; i < Rows; i++)
            {
                Data[i] = new T[Columns];
            }
            Data = CopyMatrix(temp, Data);
        }

        public static T[][] CopyMatrix(T[][] matrix1, T[][] matrix2)
        {
            for (int i = 0; i < matrix2.Length; i++)
            {
                for (int j = 0; j < matrix2[i].Length; j++)
                {
                    matrix2[i][j] = matrix1[i][j];
                }
            }
            return matrix2;
        }

        public void ExpandByStep()
        {
            ExpandByStep(iStepping);
        }

        public T[] GetRow(int idx)
        {
            return Data[idx];
        }

        public T[] GetColumn(int idx)
        {
            T[] o = new T[Rows];
            for(int i = 0; i < Rows; i++)
            {
                o[i] = GetRow(i)[idx];
            }
            return o;
        }

        override public string ToString()
        {
            string s = "";
            for(int i = 0; i < Rows; i++)
            {
                for(int j = 0; j < Columns; j++)
                {
                    s += Data[i][j].ToString() + " ";
                }
                s += Environment.NewLine;
            }
            return s;
        }

        public T ElementAt(int CellID)
        {
            int[] ids = GetElementIds(CellID);
            return Data[ids[0]][ids[1]];
        }

        private int[] GetElementIds(int CellID)
        {
            int[] i = new int[2];
            if(CellID == 0)
            {
                i[0] = 0;
                i[1] = 0;
                return i;
            }
            i[0] = CellID / Rows;
            i[1] = CellID % Columns;
            return i;
        }
    }
}
