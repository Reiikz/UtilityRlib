using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityRlib.StringHelper.NumericStringHelper;
using UtilityRlib.StringHelper.TextStringHelper;

namespace UtilityRlib.NumericHelpers
{
    public static class NumericParser
    {
        private static double getMultiplier(string s)
        {
            double multiplier = 1;
            char ch = findType(s);
            switch (ch)
            {
                case 'Y': multiplier = 1E24; break;

                case 'Z': multiplier = 1E21; break;

                case 'E': multiplier = 1E18; break;

                case 'P': multiplier = 1E15; break;

                case 'T': multiplier = 1E12; break;

                case 'G': multiplier = 1E9; break;

                case 'M': multiplier = 1E6; break;

                case 'K': multiplier = 1E3; break;

                case 'm': multiplier = 1E-3; break;

                case 'µ': multiplier = 1E-6; break;

                case 'n': multiplier = 1E-9; break;

                case 'p': multiplier = 1E-12; break;

                case 'f': multiplier = 1E-15; break;

                case 'a': multiplier = 1E-18; break;

                case 'z': multiplier = 1E-21; break;

                case 'y': multiplier = 1E-24; break;
            }
            return multiplier;
        }

        /// <summary>
        /// Returns an integer, don't worry about cleaning the string, this function is meant for that.
        /// </summary>
        /// <param name="s">Input String</param>
        /// <returns></returns>
        public static int getInt(string s)
        {
            s = s.NumericFormatting();
            if (s.Equals(""))
                return 0;
            return Convert.ToInt32(s);
        }

        /// <summary>
        /// Returns an integer, but this function is smart, if it detects a multiplier
        /// from international system of units, it'll use it too.
        /// </summary>
        /// <param name="s">Input string</param>
        /// <returns></returns>
        public static int getIntSmart(string s)
        {
            return Convert.ToInt32(getDoubleSmart(s));
        }

        /// <summary>
        /// Returns a double, don't worry about cleaning the string, this function is meant for that.
        /// </summary>
        /// <param name="s">Input String</param>
        /// <returns></returns>
        public static double getDouble(string s)
        {
            string input = s.NumericFormatting();
            double d = 0;
            if(!input.Equals(""))
            {
                d = Convert.ToDouble(input);
            }
            return d;
        }

        /// <summary>
        /// Returns a double, but this function is smart, if it detects a multiplier
        /// from international system of units, it'll use it too.
        /// </summary>
        /// <param name="s">Input string</param>
        /// <returns></returns>
        public static double getDoubleSmart(string s)
        {
            string input = s.NumericFormatting();
            double d = 0, multiplier = getMultiplier(input);
            if (!s.Equals(""))
            {
                d = Convert.ToDouble(input) * multiplier;
            }
            return d;
        }

        /// <summary>
        /// Returns an integer that is located between 2 delimiters inside a string.
        /// </summary>
        /// <param name="input">The input string</param>
        /// <param name="del1">The delimiter before the number starts</param>
        /// <param name="del2">The delimiter where the number ends</param>
        /// <returns></returns>
        public static int getIntByDelimiters(string input, string del1, char del2)
        {
            return getInt(input.SubstrByDelimiters(del1, del2));
        }

        private static char findType(String s)
        {
            char ch = 'r';
            int quantity = 0;
            if (s.Contains("Y"))
            {
                ch = 'Y';
                quantity++;
            }
            if (s.Contains("Z"))
            {
                ch = 'Z';
                quantity++;
            }
            if (s.Contains("E"))
            {
                ch = 'E';
                quantity++;
            }
            if (s.Contains("P"))
            {
                ch = 'P';
                quantity++;
            }
            if (s.Contains("T"))
            {
                ch = 'T';
                quantity++;
            }
            if (s.Contains("G"))
            {
                ch = 'G';
                quantity++;
            }
            if (s.Contains("M"))
            {
                ch = 'M';
                quantity++;
            }
            if (s.Contains("K"))
            {
                ch = 'K';
                quantity++;
            }
            if (s.Contains("m"))
            {
                ch = 'm';
                quantity++;
            }
            if (s.Contains("µ"))
            {
                ch = 'µ';
                quantity++;
            }
            if (s.Contains("micro"))
            {
                ch = 'µ';
            }
            if (s.Contains("n"))
            {
                ch = 'n';
                quantity++;
            }
            if (s.Contains("p"))
            {
                ch = 'p';
                quantity++;
            }
            if (s.Contains("f"))
            {
                ch = 'f';
                quantity++;
            }
            if (s.Contains("a"))
            {
                ch = 'a';
                quantity++;
            }
            if (s.Contains("z"))
            {
                ch = 'z';
                quantity++;
            }
            if (s.Contains("y"))
            {
                ch = 'y';
                quantity++;
            }
            if (quantity > 1)
                return 'r';
            else
                return ch;

        }

        /// <summary>
        /// Returns a nice rounded and human readable number using the multipliers from international system of units.
        /// </summary>
        /// <param name="value">The value you want to convert</param>
        /// <returns></returns>
        public static string GetSIUMultiplier(double value)
        {
            return GetSIUMultiplier(value, false, 1);
        }

        /// <summary>
        /// Returns a nice human readable number using the multipliers from international system of units.
        /// </summary>
        /// <param name="value">The value you want to convert</param>
        /// <param name="rounded">True if you want round the value</param>
        /// <param name="QuantityOfToRound">The decimal places that you want</param>
        /// <returns></returns>
        public static string GetSIUMultiplier(double value, bool rounded, int QuantityOfToRound)
        {
            string s = "";
            double multiplier = 1000, t = 0;
            int used = 0;
            bool division = false, isNegative = false;
            if (value < 0)
            {
                isNegative = true;
                value *= -1;
            }
            if (!(value >= 1 && value < 1000))
            {
                if (value < 1)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        t = value * multiplier;
                        used = i;
                        if (t >= 1 && t < 1000)
                            break;
                        multiplier *= 1000;
                    }
                    division = false;
                }
                else
                {
                    for (int i = 0; i < 7; i++)
                    {
                        t = value / multiplier;
                        used = i;
                        if (t >= 1 && t < 1000)
                            break;
                        multiplier *= 1000;
                    }
                    division = true;
                }
                if (rounded && QuantityOfToRound >= 1)
                {
                    t = Math.Round(t, QuantityOfToRound);
                }
                if (isNegative)
                    t *= -1;
                switch (used)
                {
                    case 0:
                        {
                            if (division)
                                s = t + " K";
                            else
                                s = t + " m";

                            break;
                        }
                    case 1:
                        {
                            if (division)
                                s = t + " M";
                            else
                                s = t + " µ";

                            break;
                        }
                    case 2:
                        {
                            if (division)
                                s = t + " G";
                            else
                                s = t + " n";

                            break;
                        }
                    case 3:
                        {
                            if (division)
                                s = t + " T";
                            else
                                s = t + " p";

                            break;
                        }
                    case 4:
                        {
                            if (division)
                                s = t + " P";
                            else
                                s = t + " f";

                            break;
                        }
                    case 5:
                        {
                            if (division)
                                s = t + " E";
                            else
                                s = t + " a";

                            break;
                        }
                    case 6:
                        {
                            if (division)
                                s = t + " Z";
                            else
                                s = t + " z";

                            break;
                        }
                    case 7:
                        {
                            if (division)
                                s = t + " Y";
                            else
                                s = t + " y";

                            break;
                        }
                }
            }
            else
            {
                if (rounded && QuantityOfToRound >= 1)
                {
                    value = Math.Round(t, QuantityOfToRound);
                }
                if (isNegative)
                    value *= -1;
                s = value + " ";
            }
            return s;
        }
    }
}
