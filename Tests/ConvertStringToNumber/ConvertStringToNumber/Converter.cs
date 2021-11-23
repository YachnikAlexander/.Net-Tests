using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertStringToNumber
{
    public static class Converter
    {
        #region Const
        private const string NUMBERS = "0123456789ABCDEF";
        private const int MAX_STRING_LENGTH = 31;
        #endregion

        #region PublicAPI
        /// <summary>
        /// Method for converting string presentation of any base(from 2 to 16) to decimal number 
        /// </summary>
        /// <param name="numberStr">string of number of any base</param>
        /// <param name="_base">base of string</param>
        /// <returns>decimal number</returns>
        /// <exception cref="ArgumentNullException">string argument is null</exception>
        /// <exception cref="ArgumentException">string argument is null</exception>
        /// <exception cref="ArgumentException">string argument is empty</exception>
        /// <exception cref="OverflowException">string argument number is more that can store</exception>
        /// <exception cref="ArgumentException">base is less than 2 or more than 16</exception>
        /// <exception cref="ArgumentException">string argument contains incorrect symbols according to the base</exception>
        public static int StringToInt(this string numberStr, int _base)
        {
            IsValid(numberStr, _base);
            int number = StartConvertToInt(numberStr, _base);
            return number;
        }
        #endregion

        #region Private
        private static int StartConvertToInt(string numberStr, int _base)
        {
            int result = 0;
            for (int i = 0; i < numberStr.Length; i++)
            {
                int number = NUMBERS.IndexOf(numberStr[i]);

                int PowNeeded = (int)Math.Pow(_base, numberStr.Length - i - 1);

                if (Int32.MaxValue - result < number * PowNeeded)
                {
                    throw new OverflowException(nameof(numberStr));
                }

                result += number * PowNeeded;
            }
            return result;
        }

        private static void IsValid(string str, int _base)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (str.Length == 0)
            {
                throw new ArgumentException(nameof(str));
            }

            if (str.Length > MAX_STRING_LENGTH)
            {
                throw new OverflowException(nameof(str));
            }

            if (_base < 2 || _base > 16)
            {
                throw new ArgumentException(nameof(_base));
            }

            for (int i = 0; i < str.Length; i++)
            {
                int number = NUMBERS.IndexOf(str[i]);
                if (number > _base)
                {
                    throw new ArgumentException(nameof(str));
                }
            }
        }
        #endregion
    }
}
