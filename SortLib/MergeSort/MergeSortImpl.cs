using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



//public static class MergeSort
//{

//    public static void Sort(int[] array)
//    {
//        Prove(array, 0, array.Length - 1);
//    }
//    private static void Merge(int[] input, int left, int mid, int right)
//    {

//        int[] temp = new int[input.Length];
//        int i, leftEnd, lengthOfInput, tmpPos;
//        leftEnd = mid - 1;
//        tmpPos = left;
//        lengthOfInput = right - left + 1;


//        while ((left <= leftEnd) && (mid <= right))
//        {
//            if (input[left] <= input[mid])
//            {
//                temp[tmpPos++] = input[left++];
//            }
//            else
//            {
//                temp[tmpPos++] = input[mid++];
//            }
//        }

//        while (left <= leftEnd)
//        {
//            temp[tmpPos++] = input[left++];
//        }


//        while (mid <= right)
//        {
//            temp[tmpPos++] = input[mid++];
//        }


//        for (i = 0; i < lengthOfInput; i++)
//        {
//            input[right] = temp[right];
//            right--;
//        }
//    }

//    private static void Prove(int[] array, int startIndex, int endIndex)
//    {

//        if (endIndex > startIndex)
//        {
//            int mid = (endIndex + startIndex) / 2;
//            Prove(array, startIndex, mid);
//            Prove(array, (mid + 1), endIndex);
//            Merge(array, startIndex, (mid + 1), endIndex);
//        }
//    }
//}

namespace SortLib.MergeSort;

public static class MergeSort
{
    public static void Sort<T>(T[] array) where T : IComparable<T>
    {
        Sort(array, (x, y) => x.CompareTo(y));
    }

    public static void Sort<T>(T[] array, IComparer<T> comparer)
    {
        if (comparer == null)
        {
            throw new ArgumentNullException(nameof(comparer));
        }
        Sort(array, (x, y) => comparer.Compare(x, y));
    }

    public static void Sort<T>(T[] array, Func<T, T, int> comparer)
    {
        if (array.Length == 0)
        {
            return;
        }
        MergeSortImpl<T> mergeSort = new MergeSortImpl<T>(array.Length, comparer);
        mergeSort.Sort(array, 0, array.Length - 1);
    }

    private class MergeSortImpl<T>
    {
        private T[] _tempArray;
        private Func<T, T, int> _comparer;

        public MergeSortImpl(int n, Func<T, T, int> comparer)
        {
            _tempArray = new T[n];
            _comparer = comparer;
        }

        public void Sort(T[] array, int low, int high)
        {
            if (low < high)
            {
                int mid = (low + high) / 2;
                Sort(array, low, mid);
                Sort(array, mid + 1, high);
                Merge(array, low, mid, high);
            }
        }

        private void Merge(T[] array, int low, int mid, int high)
        {
            int i1 = low;
            int i2 = mid + 1;
            bool choose1;

            for (int i = low; i <= high; i++)
            {
                if (i1 > mid)
                {
                    choose1 = false;
                }
                else if (i2 > high)
                {
                    choose1 = true;
                }
                else
                {
                    choose1 = _comparer(array[i1], array[i2]) < 0;
                }

                if (choose1)
                {
                    _tempArray[i] = array[i1];
                    ++i1;
                }
                else
                {
                    _tempArray[i] = array[i2];
                    ++i2;
                }
            }

            for (int i = low; i <= high; ++i)
            {
                array[i] = _tempArray[i];
            }
        }
    }
}
