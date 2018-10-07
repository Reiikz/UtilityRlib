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
        /// <summary>
        /// counts the number of characters that are before a given delimiter.
        /// </summary>
        /// <param name="del">the delimiter</param>
        /// <returns></returns>
        public static int CountCharsToDelimiter(this String str, string[] del)
        {
            int[] o = new int[del.Length];
            for (int i = 0; i < del.Length; i++)
            {
                o[i] = CountCharsToDelimiter(str, del[i]);
            }
            return CollectionHelper.FindSmallest(o);
        }

        /// <summary>
        /// Returns a substring between two delimiters.
        /// </summary>
        /// <param name="del1">first delimiter</param>
        /// <param name="del2">second delimiter</param>
        /// <returns></returns>
        public static string SubstrByDelimiters(this String input, string del1, char del2)
        {
            string str;
            str = input.Substring(input.IndexOf(del1) + del1.Length);
            str = str.Substring(0, CountCharsToDelimiter(str, del2));
            return str;
        }

        /// <summary>
        /// counts the number of characters that are before a given delimiter.
        /// </summary>
        /// <param name="del">the delimiter</param>
        /// <returns></returns>
        public static int CountCharsToDelimiter(this String input, char del)
        {
            return CountCharsToDelimiter(input, del, 0);
        }

        /// <summary>
        /// counts the number of characters that are before a given delimiter.
        /// </summary>
        /// <param name="del">the delimiter</param>
        /// <returns></returns>
        public static int CountCharsToDelimiter(this String input, string del)
        {
            return CountCharsToDelimiter(input, del, 0);
        }

        /// <summary>
        /// counts the number of characters that are before a given delimiter starting from a given index.
        /// </summary>
        /// <param name="del">The delimiter</param>
        /// <param name="offset">The index from wich start checking</param>
        /// <returns></returns>
        public static int CountCharsToDelimiter(this String input, string del, int offset)
        {
            string s = input.Substring(offset);
            return s.IndexOf(del);
        }

        /// <summary>
        /// counts the number of characters that are before a given delimiter starting from a given index.
        /// </summary>
        /// <param name="del">The delimiter</param>
        /// <param name="offset">The index from wich start checking</param>
        /// <returns></returns>
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

        /// <summary>
        /// Counts how many times a string is contained inside other
        /// </summary>
        /// <param name="find">The string you want to compare</param>
        /// <returns></returns>
        public static int CountText(this String str, string find)
        {
            string s2 = str.Replace(find, "");
            return (str.Length - s2.Length) / find.Length;
        }

        /// <summary>
        /// A very loved function that returns an array of all the substrings separated by a given delimiter.
        /// </summary>
        /// <param name="del">The delimiter</param>
        /// <returns></returns>
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
