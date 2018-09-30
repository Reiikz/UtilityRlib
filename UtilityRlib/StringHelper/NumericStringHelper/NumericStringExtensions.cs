using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityRlib.StringHelper.NumericStringHelper
{
    public static class NumericStringExtensions
    {

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

        public static string AbsIntNumericFormatting(this String s)
        {
            s = NumericFormatting(s).Replace(",", "");
            s = NumericFormatting(s).Replace("-", "");
            return s;
        }

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
