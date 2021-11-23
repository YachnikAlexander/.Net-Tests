namespace ArrayExtensions
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// class to determine digit
    /// </summary>
    public class ArrayExtensions
    {
        public static int[] FilterNumbers(int[] source, int digit, string method = "byInt")
        {
            IsValid(source, digit, method);

            int[] arr = StartFilterNumbers(source, digit, method);

            return arr;
        }

        private static int[] StartFilterNumbers(int[] source, int digit, String method)
        {
            List<int> list = new List<int>();
            if (method == "byInt")
            {
                for (int i = 0; i < source.Length; i++)
                {
                    if (IsDigit(source[i], digit))
                    {
                        list.Add(source[i]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < source.Length; i++)
                {
                    if (IsDigitByString(source[i], digit))
                    {
                        list.Add(source[i]);
                    }
                }
            }


            int[] listInt = list.ToArray();
            return listInt;
        }

        private static bool IsDigitByString(int number, int digit)
        {
            string numb = number.ToString();
            string dig = digit.ToString();

            bool existence = numb.Contains(dig);
            return existence;
        }

        private static bool IsValid(int[] source, int digit, string method)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (method != "byInt")
            {
                if (method == null)
                {
                    throw new ArgumentNullException(nameof(method));
                }

                if (method != "byString")
                {
                    throw new ArgumentException(nameof(method));
                }
            }

            if (source.Length == 0)
            {
                throw new ArgumentException(nameof(source));
            }

            if (digit < 0 || digit > 9)
            {
                throw new ArgumentOutOfRangeException(nameof(digit));
            }

            return true;
        }

        private static bool IsDigit(int number, int digit)
        {
            if (digit != 0)
            {
                if (number < 0)
                {
                    number *= -1;
                }

                while (number != 0)
                {
                    int t = number % 10;

                    if (t == digit)
                    {
                        return true;
                    }

                    number /= 10;
                }
            }
            else
            {
                if (number == 0 || number % 10 == 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
