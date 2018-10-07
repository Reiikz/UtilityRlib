using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityRlib.StringHelper.NumericStringHelper
{
    public static class NumericStringExtensions
    {
        /// <summary>
        /// Returns if the string is numeric.
        /// <para>(It just checks if there another character apart from { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', ',', '.', '-' })</para>
        /// </summary>
        /// <returns></returns>
        public static bool IsNumeric(this String str)
        {
            foreach (char c in str)
            {
                if (!CompareToNumericAllowedChars(c))
                    return false;
            }
            return true;
        }

        private static bool CompareToNumericAllowedChars(char c)
        {
            char[] allowedChars = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', ',', '.', '-' };
            byte failCount = 0;
            foreach(char cc in allowedChars)
            {
                if (c != cc)
                    failCount++;
            }
            if (failCount == 13)
                return false;
            return true;
        }

        /// <summary>
        /// Returns if the character at a given index is a digit
        /// </summary>
        /// <param name="index">The index of the character you want to check</param>
        /// <returns></returns>
        public static bool IsDigit(this String str, int index)
        {
            int failCount = 0;
            char[] allowedChars = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            foreach (char item in allowedChars)
            {
                if (str[index] != item)
                    failCount++;
            }
            if (failCount > 9)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Returns a nice machine readble numeric string with absolute values and no decimal places after comma (no commas dots or dashes)
        /// </summary>
        /// <returns></returns>
        public static string AbsIntNumericFormatting(this String s)
        {
            s = NumericFormatting(s).Replace(",", "");
            s = NumericFormatting(s).Replace("-", "");
            return s;
        }

        /// <summary>
        /// Returns a nice machine readable numeric string.
        /// </summary>
        /// <returns></returns>
        public static string NumericFormatting(this String s)
        {
            char[] allowCh = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            int i = 0, failCount = 0, commaCount = 0, dashCount = 0;
            s = s.Replace(".", ",");
            while (i < s.Length)
            {
                failCount = 0;
                for (int j = 0; j < 10; j++)
                {
                    if (s[i] != allowCh[j])
                        failCount++;
                }
                if ((failCount == 10 && s[i] != ',' && s[i] != '-') || (commaCount >= 1 && s[i] == ',') || (dashCount >= 1 && s[i] == '-'))
                {
                    s = s.Remove(i, 1);
                    continue;
                }
                if (s[i] == ',')
                    commaCount++;
                if (s[i] == '-')
                    dashCount++;
                i++;
            }
            if (dashCount >= 1)
                s = '-' + s.Replace("-", "");
            s = s.Replace(" ", "");
            return s;
        }
    }
}
