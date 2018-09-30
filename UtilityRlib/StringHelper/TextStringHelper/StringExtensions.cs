using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityRlib.CollectionHelpers;

namespace UtilityRlib.StringHelper.TextStringHelper
{
    public static class StringExtensions
    {
        public static int CountCharsToDelimiter(this String str, string[] del)
        {
            int[] o = new int[del.Length];
            for (int i = 0; i < del.Length; i++)
            {
                o[i] = CountCharsToDelimiter(str, del[i]);
            }
            return CollectionHelper.FindSmallest(o);
        }

        public static string SubstrByDelimiters(this String input, string del1, char del2)
        {
            string str;
            str = input.Substring(input.IndexOf(del1) + del1.Length);
            str = str.Substring(0, CountCharsToDelimiter(str, del2));
            return str;
        }

        public static int CountCharsToDelimiter(this String input, char del)
        {
            return CountCharsToDelimiter(input, del, 0);
        }

        public static int CountCharsToDelimiter(this String input, string del)
        {
            return CountCharsToDelimiter(input, del, 0);
        }

        public static int CountCharsToDelimiter(this String input, string del, int offset)
        {
            string s = input.Substring(offset);
            return s.IndexOf(del);
        }

        public static int CountCharsToDelimiter(this String input, char del, int offset)
        {
            int count = 0;
            char[] chars = input.ToCharArray();
            for (int i = offset; i < chars.Length; i++)
            {
                if (chars[i] != del)
                {
                    count++;
                }
                else
                {
                    break;
                }
            }
            return count;
        }

        public static int CountText(this String str, string find)
        {
            string s2 = str.Replace(find, "");
            return (str.Length - s2.Length) / find.Length;
        }

        public static string[] Explode(this String str, string del)
        {
            int c = CountText(str, del), nextIndex = 0, lastIndex = 0;
            int cc = c;
            bool b = false;
            string[] s;
            if (str.EndsWith(del))
                s = new string[c];
            else
            {
                c++;
                s = new string[c];
                b = true;
            } 
            for(int i = 0; i < cc; i++)
            {
                nextIndex = str.IndexOf(del, lastIndex);
                s[i] = str.Substring(lastIndex, CountCharsToDelimiter(str, del, lastIndex));
                lastIndex = nextIndex + del.Length;
            }
            if (b)
                s[s.Length - 1] = str.Substring(lastIndex);
            return s;
        }
    }
}
