using SortLib.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortLib.BubbleSort;

public class BubbleSort
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
        if (comparer == null)
        {
            throw new ArgumentNullException(nameof(comparer));
        }

        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (comparer(array[i], array[j]) > 0)
                {
                    Utiles.Change(array, i, j);
                }
            }
        }
    }





    //for (int i = 0; i < array.Length; i++)
    //{
    //    for (int j = i + 1; j < array.Length; j++)
    //    {
    //        int compare = comparer.Compare(array[i], array[j]);
    //        if (compare == 0)
    //        {
    //            compare = comparer2.Compare(array[i], array[j]);
    //            if (compare == 0)
    //            {
    //                compare = comparer3.Compare(array[i], array[j]);
    //            }
    //        }

    //        if (compare > 0)
    //        {
    //            Utiles.Change(array, i, j);
    //        }
    //    }
    //}

}

