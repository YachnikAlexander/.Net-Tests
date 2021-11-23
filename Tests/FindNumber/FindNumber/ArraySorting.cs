using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySorting
{
    /// <summary>
    /// class Sort
    /// </summary>
    public static class Sort
    {
        #region public API
        /// <summary>
        /// static extending method for sort array with 3 arguments
        /// </summary>
        /// <param name="unsortedArray">array needed to sort</param>
        /// <param name="leftIndex">index from which start sort</param>
        /// <param name="rightIndex">index to which sort</param>
        public static void MergeSort(this int[] unsortedArray, int leftIndex, int rightIndex)
        {
            IsValid(unsortedArray, leftIndex, rightIndex);
            StartMergeSort(unsortedArray, leftIndex, rightIndex);
        }

        /// <summary>
        /// extending overloaded method with 1 argument for sort whole array
        /// </summary>
        /// <param name="unsortedArray">array needed to sort</param>
        /// <returns>sorted array</returns>
        public static void MergeSort(this int[] unsortedArray)
        {
            IsValid(unsortedArray);

            int lenght = unsortedArray.Length;
            StartMergeSort(unsortedArray, 0, lenght - 1);

        }

        /// <summary>
        /// extending static method for sort array with 3 arguments
        /// </summary>
        /// <param name="unsortedArray">array needed to sort</param>
        /// <param name="start">index from which start sort</param>
        /// <param name="end">index to which sort</param>
        /// <returns>sorted array</returns>
        public static void QuickSort(this int[] unsortedArray, int start, int end)
        {
            IsValid(unsortedArray, start, end);
            StartQuickSort(unsortedArray, start, end);

        }

        /// <summary>
        /// extending static method for sort array with 1 arguments
        /// </summary>
        /// <param name="unsortedArray">array needed to sort</param>
        /// <returns>sorted array</returns>
        public static void QuickSort(this int[] unsortedArray)
        {
            IsValid(unsortedArray);

            int length = unsortedArray.Length;
            StartQuickSort(unsortedArray, 0, length - 1);
        }
        #endregion

        #region privateMergeSort
        /// <summary>
        /// start method of merge sort
        /// </summary>
        /// <param name="unsortedArray">array needed to sort</param>
        /// <param name="leftIndex">index from which start sort</param>
        /// <param name="rightIndex">index to which sort</param>
        private static void StartMergeSort(int[] unsortedArray, int leftIndex, int rightIndex)
        {
            if (leftIndex < rightIndex)
            {
                int middleIndex = (leftIndex + rightIndex) / 2;
                MergeSort(unsortedArray, leftIndex, middleIndex);
                MergeSort(unsortedArray, middleIndex + 1, rightIndex);
                DoMerge(unsortedArray, leftIndex, middleIndex, rightIndex);
            }
        }

        /// <summary>
        /// method for forming 2 subarraies
        /// </summary>
        /// <param name="unsortedArray">array needed to sort</param>
        /// <param name="leftIndex">index from which start sort</param>
        /// <param name="middleIndex">middle index between left and right indexes</param>
        /// <param name="rightIndex">index to which sort</param>
        private static void DoMerge(int[] unsortedArray, int leftIndex, int middleIndex, int rightIndex)
        {
            int lengthLeft = middleIndex - leftIndex + 1;
            int lengthRight = rightIndex - middleIndex;
            int[] leftArray = new int[lengthLeft + 1];
            int[] rightArrray = new int[lengthRight + 1];

            for (int i = 0; i < lengthLeft; i++)
            {
                leftArray[i] = unsortedArray[leftIndex + i];
            }

            for (int j = 0; j < lengthRight; j++)
            {
                rightArrray[j] = unsortedArray[middleIndex + j + 1];
            }

            leftArray[lengthLeft] = int.MaxValue;
            rightArrray[lengthRight] = int.MaxValue;

            BuildingArray(unsortedArray, leftArray, rightArrray, leftIndex, rightIndex);
        }

        /// <summary>
        /// method for building sorting array
        /// </summary>
        /// <param name="unsortedArray">array needed to sort</param>
        /// <param name="leftArray">left subarray</param>
        /// <param name="rightArrray">right subarray</param>
        /// <param name="leftIndex">index from which start sort</param>
        /// <param name="rightIndex">index to which sort</param>
        private static void BuildingArray(int[] unsortedArray, int[] leftArray, int[] rightArrray, int leftIndex, int rightIndex)
        {
            int indexi = 0;
            int indexj = 0;

            for (int k = leftIndex; k <= rightIndex; k++)
            {
                if (leftArray[indexi] <= rightArrray[indexj])
                {
                    unsortedArray[k] = leftArray[indexi];
                    indexi++;
                }
                else
                {
                    unsortedArray[k] = rightArrray[indexj];
                    indexj++;
                }
            }
        }
        #endregion

        #region privateQuickSort
        /// <summary>
        /// method for finding partition of array
        /// </summary>
        /// <param name="unsortedArray">array needed to sort</param>
        /// <param name="start">index from which start sort</param>
        /// <param name="end">index to which sort</param>
        /// <returns>index of partiotion</returns>
        private static int Partition(int[] unsortedArray, int start, int end)
        {
            int pivot = unsortedArray[start];

            while (true)
            {
                while (unsortedArray[start] < pivot)
                {
                    start++;
                }

                while (unsortedArray[end] > pivot)
                {
                    end--;
                }

                if (start < end)
                {
                    if (unsortedArray[start] == unsortedArray[end])
                    {
                        return end;
                    }

                    int temp = unsortedArray[start];
                    unsortedArray[start] = unsortedArray[end];
                    unsortedArray[end] = temp;
                }
                else
                {
                    return end;
                }
            }
        }

        /// <summary>
        /// start method of quick sort
        /// </summary>
        /// <param name="unsortedArray">array needed to sort</param>
        /// <param name="start">index from which start sort</param>
        /// <param name="end">index to which sort</param>
        private static void StartQuickSort(int[] unsortedArray, int start, int end)
        {
            if (start < end)
            {
                int pivot = Partition(unsortedArray, start, end);

                if (pivot > 1)
                {
                    StartQuickSort(unsortedArray, start, pivot - 1);
                }

                if (pivot + 1 < end)
                {
                    StartQuickSort(unsortedArray, pivot + 1, end);
                }
            }
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unsortedArray"></param>
        /// <param name="leftIndex"></param>
        /// <param name="rightIndex"></param>
        /// <returns></returns>
        private static bool IsValid(int[] unsortedArray, int leftIndex = 0, int rightIndex = 1)
        {
            if (unsortedArray == null)
            {
                throw new ArgumentNullException($"Array {0} is null ", nameof(unsortedArray));
            }

            if (unsortedArray.Length == 0)
            {
                throw new ArgumentException($"The length of {0} 0", nameof(unsortedArray));
            }

            if (unsortedArray.Length == 1)
            {
                return false;
            }

            return true;
        }
    }
}
