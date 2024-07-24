using SortLib.Support;

namespace SortLib.SelectionSort;

public class SelectionSort
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
            int indexOfMin = i;
            for (int j = i + 1; j < array.Length; j++)
            {
                if (comparer(array[j], array[indexOfMin]) < 0)
                {
                    indexOfMin = j;
                }
            }
            Utiles.Change(array, i, indexOfMin);
        }



    }
}
