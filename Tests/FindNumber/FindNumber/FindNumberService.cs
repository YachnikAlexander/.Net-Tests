using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArraySorting;
using System.Diagnostics;

namespace FindNumber
{
    /// <summary>
    /// Class for finding numbers
    /// </summary>
    public class FindNumberService
    {
        /// <summary>
        /// Gets the Time of calculation
        /// </summary>
        /// <value>Store the time of calculating</value>
        public static Stopwatch Time { get; private set; }

        /// <summary>
        /// Public Api for finding next Bigger number
        /// </summary>
        /// <param name="number">number of which must to find</param>
        /// <returns>next bigger number</returns>
        public static int FindBiggerNumber(int number)
        {
            Time = new Stopwatch();
            Time.Start();

            if (IsValid(number))
            {
                int finalNumber = StartFindBiggerNumber(number);
                Time.Stop();
                return finalNumber;
            }
            else
            {
                Time.Stop();
                return number;
            }
        }

        /// <summary>
        /// fixate time of calculation
        /// </summary>
        /// <returns>string of time calculation</returns>
        public static string TimeOfCalculation()
        {
            TimeSpan time = Time.Elapsed;

            string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", time.Hours, time.Minutes, time.Seconds, time.Milliseconds / 10);

            return elapsedTime;
        }

        /// <summary>
        /// Start method for finding next bigger number
        /// </summary>
        /// <param name="number">number of which must to find</param>
        /// <returns>next bigger number or 1 if this number isnt exist</returns>
        private static int StartFindBiggerNumber(int number)
        {
            int[] arraySplitNumber = SplitNumber(number);
            int reverseIndex = FindElementsToSwap(arraySplitNumber);
            if (reverseIndex > 0)
            {
                Swap(ref arraySplitNumber[reverseIndex], ref arraySplitNumber[reverseIndex - 1]);

                int index = arraySplitNumber.Length - reverseIndex - 1;

                if (index > 0)
                {
                    ArraySorting.Sort.MergeSort(arraySplitNumber, index, arraySplitNumber.Length - 1);
                }

                int finalNumber = FormingBiggerNumber(arraySplitNumber);

                return finalNumber;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// Find elements need to swap in array of splitting number
        /// </summary>
        /// <param name="splitArray">array consist of splitting digits of numbers</param>
        /// <returns>index of first swapping elements or -1 if this index isnt exist</returns>
        private static int FindElementsToSwap(int[] splitArray)
        {
            int index = -1;
            for (int i = splitArray.Length - 1; i > 0; i--)
            {
                if (splitArray[i] > splitArray[i - 1])
                {
                    //Swap(ref splitArray[i], ref splitArray[i - 1]);
                    index = i;
                    break;
                }
            }

            return index;
        }

        /// <summary>
        /// Swap 2 elemets
        /// </summary>
        /// <param name="firstNumber">first number to swap</param>
        /// <param name="secondNumber">second number to swap</param>
        private static void Swap(ref int firstNumber, ref int secondNumber)
        {
            int temp = firstNumber;
            firstNumber = secondNumber;
            secondNumber = temp;
        }

        /// <summary>
        /// method for forming number by array
        /// </summary>
        /// <param name="splitArray">array consist of digit by split number</param>
        /// <returns>final number</returns>
        private static int FormingBiggerNumber(int[] splitArray)
        {
            int length = splitArray.Length;
            int finalNumber = 0;
            for (int i = 0; i < length; i++)
            {
                int digit = splitArray[i];
                finalNumber += (int)(digit * Math.Pow(10, length - (i + 1)));
            }

            return finalNumber;
        }

        /// <summary>
        /// split number to array of digits
        /// </summary>
        /// <param name="number">number needed to split</param>
        /// <returns>array of digits</returns>
        private static int[] SplitNumber(int number)
        {
            List<int> splitNumber = new List<int>();
            while (number != 0)
            {
                int digit = number % 10;
                splitNumber.Add(digit);
                number /= 10;
            }

            splitNumber.Reverse();

            return splitNumber.ToArray();
        }

        /// <summary>
        /// check the validation of data
        /// </summary>
        /// <param name="number">number of which must to find next bigger number</param>
        /// <returns>bool type of validate date </returns>
        private static bool IsValid(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException(nameof(number));
            }

            if (number < 10)
            {
                return false;
            }

            return true;
        }
    }
}
