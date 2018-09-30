using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityRlib.NumericHelpers
{
    public class IntVector4
    {
        public int top { get; }
        public int bottom { get; }
        public int left { get; }
        public int right { get; }

        public IntVector4(int Top, int Bottom, int Left, int Right)
        {
            top = Top;
            bottom = Bottom;
            left = Left;
            right = Right;
        }

        public IntVector2 ToVector2Sum()
        {
            return new IntVector2(top + bottom, left + right);
        }

        public static IntVector4 GetEmptyVec()
        {
            return new IntVector4(0, 0, 0, 0);
        }
    }
}
