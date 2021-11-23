using System;

namespace InsertBitNumber
{
    /// <summary>
    /// class BitInsert with public APIA: InsertNumber();
    /// </summary>
    public class BitInsert
    {
        private const int MAXBIT = 31;
        /// <summary>
        /// public method for call InsertNumber
        /// </summary>
        /// <param name="firstNumber">number to what insert</param>
        /// <param name="secondNumber">number what insert </param>
        /// <param name="i">begin index of bits</param>
        /// <param name="j">final index of bits</param>
        /// <returns>finalNumber of inserting</returns>
        /// <exception cref="ArgumentOutOfRangeException">the exception flies when i more than 0 or j less than 31</exception>
        /// <exception cref="ArgumentException">the exception flies when The argument j is more than i</exception>
        public static int InsertNumber(int firstNumber, int secondNumber, int i, int j)
        {
            if (i < 0 || j > MAXBIT)
            {
                throw new ArgumentOutOfRangeException($"The arguments {0} or {1} are out of (0,31)", nameof(i), nameof(j));
            }

            if (j < i)
            {
                throw new ArgumentException($"The argument {0} is less than i", nameof(j));
            }

            int finalNumber = StartInsertArray(firstNumber, secondNumber, i, j);

            return finalNumber;
        }

        /// <summary>
        /// Start insert numbers
        /// </summary>
        /// <param name="firstNumber">number to what insert</param>
        /// <param name="secondNumber">number what insert </param>
        /// <param name="i">begin index of bits</param>
        /// <param name="j">final index of bits</param>
        /// <returns>finalNumber of inserting</returns>
        private static int StartInsertArray(int firstNumber, int secondNumber, int i, int j)
        {
            // make a mask (for i=3 && j=8 mask == 111111)
            int mask = (1 << (j - i + 1)) - 1;

            // make a mask of second number (for sN = 15 secondNumberMask==1111000)
            int secondNumberMask = (secondNumber & mask) << i;

            // change mask location on i-bit to left side for first number (for i=3 mask == 000000111)
            mask = ~((1 << i) - 1);

            // getting the ending bits of finalNumber (for firstNumber=8 firstNumberMask == 000)
            int firstNumberMask = firstNumber & mask;

            // make final number by logic summer
            int finalNumber = secondNumberMask | firstNumberMask;
            return finalNumber;
        }
    }
}
