using SortLib.Support;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SortLib.QuickSort;

public static class QuickSort

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
        Pivot(array, 0, array.Length - 1, comparer);
    }

    private static void Pivot<T>(T[] array, int low, int high, Func<T, T, int> comparer)
    {
        int i = low;
        int j = high;

        T pivot = GetPivot(array, low, high, comparer);

        while (i <= j)
        {
            while (comparer(array[i], pivot) < 0)
            {
                i++;
            }

            while (comparer(array[j], pivot) > 0)
            {
                j--;
            }

            if (i <= j)
            {
                Utiles.Change(array, i, j);
                i++;
                j--;
            }
        }

        if (low < j)
        {
            Pivot(array, low, j, comparer);
        }

        if (i < high)
        {
            Pivot(array, i, high, comparer);
        }
    }

    private static readonly Random random = new Random();

    private static (int, int, int) GetRandomIndexes(int low, int high)
    {
        int a = random.Next(low, high + 1);
        int b = random.Next(low, high + 1);
        int c = random.Next(low, high + 1);

        return (a, b, c);
    }

    private static T GetPivot<T>(T[] array, int low, int high, Func<T, T, int> comparer)
    {
        (int i, int j, int k) = GetRandomIndexes(low, high);
        return Utiles.Median(array[i], array[j], array[k], comparer);
    }
}

    

    



