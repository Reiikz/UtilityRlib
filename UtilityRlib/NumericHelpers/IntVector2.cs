using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace UtilityRlib.NumericHelpers
{
    public class IntVector2
    {
        public int X { get; set; }
        public int Y { get; set; }

        public IntVector2() : this(0, 0) { }

        public IntVector2(int x, int y)
        {
            X = x;
            Y = y;
        }

        public IntVector2 AddForce(IntVector2 vec)
        {
            return new IntVector2(this.X + vec.X, this.Y + vec.Y);
        }

        public IntVector2 RestForece(IntVector2 vec)
        {
            return new IntVector2(this.X - vec.X, this.Y - vec.Y);
        }

        public static IntVector2 GetEmptyVec()
        {
            return new IntVector2(0, 0);
        }

        public Point getAsPoint()
        {
            return new Point(X, Y);
        }

        public Size getAsSize()
        {
            return new Size(X, Y);
        }

        public override string ToString()
        {
            return "X: " + X + " Y: " + Y;
        }
    }
}
