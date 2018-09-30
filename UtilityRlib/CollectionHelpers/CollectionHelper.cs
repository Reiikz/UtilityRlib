using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityRlib.CollectionHelpers
{
    public abstract class CollectionHelper
    {

        public static int FindSmallest(int[] input)
        {
            int idx = 0;
            for(int i = 0; i < input.Length; i++)
            {
                if (input[i] < input[idx])
                    idx = i;
            }
            return input[idx];
        }

        public static int sumAllInt(int[] coll)
        {
            int temp = 0;
            foreach(int i in coll)
            {
                temp += i;
            }
            return temp;
        }

        public static int CountOf(string[] input, string text)
        {
            int o = 0;
            for(int i = 0; i < input.Length; i++)
            {
                if (input[i].Contains(text))
                    o++;
            }
            return o;
        }
    }
}
