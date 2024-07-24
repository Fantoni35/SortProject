using SortLib.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortLib.Support;



    public static class Utiles
    {
        public static void Change<T>(T[] array, int i, int j)
        {
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

    public static T Median<T>(T a, T b, T c, Func<T, T, int> comparer)
    {
        if (comparer(a, b) > 0)
        {
            if (comparer(a, c) < 0)
            {
                return a;
            }
            if (comparer(b, c) > 0)
            {
                return b;
            }

            return c;

        }
        else
        {
            if (comparer(a, c) > 0)
            {
                return a;
            }
            if (comparer(b, c) < 0)
            {
                return b;
            }
            return c;

        }
    }


    public static int NullException(object x, object y)
        {
            if (x is null && y is null)
            {
                return 0;
            }
            if (x is null)
            {
                return -1;
            }
            if (y is null)
            {
                return 1;
            }
            return 0;
        }
    }

