using FluentAssertions;
using SortLib.BubbleSort;
using SortLib.Person;
using SortLib.QuickSort;
using SortLib.SelectionSort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortLibTest1
{
    public class QuickSortTests
    {
        [Fact]
        public void SortWithRandomNumberShouldWork()
        {
            int[] array = { 15, 10, 54, 34, 2, 21 };
            QuickSort.Sort(array);
            array.Should().Equal([2, 10, 15, 21, 34, 54]);
        }

        [Fact]
        public void SortOrderNumbersShouldWork()
        {
            int[] array = { 2, 6, 14, 22, 44, 67 };
            QuickSort.Sort(array);
            array.Should().Equal([2, 6, 14, 22, 44, 67]);
        }

        [Fact]
        public void SortReverseNumberShouldWork()
        {
            int[] array = { 87, 76, 65, 54, 46, 32 };
            QuickSort.Sort(array);
            array.Should().Equal([32, 46, 54, 65, 76, 87]);
        }

        [Fact]
        public void SortEmptyArrayShouldWork()
        {
            int[] array = { };
            QuickSort.Sort(array);
            array.Should().Equal(array);
        }

        [Fact]
        public void SortStringShouldWork()
        {
            string[] array = { "", "", "", "" };
            QuickSort.Sort(array);
            array.Should().Equal(["", "", "", ""]);
        }
        [Fact]
        public void SortDoubleRandomShouldWork()
        {
            double[] array = { 22.2, 33.3, 44.4, 11.3, 21.2 };
            QuickSort.Sort(array);
            array.Should().Equal([11.3, 21.2, 22.2, 33.3, 44.4]);
        }

        [Fact]
        public void SortDateRandomShouldWork()
        {
            DateTime[] array = {
            new DateTime(2022, 5, 1),
            new DateTime(2019, 4, 18),
            new DateTime(2020,4,13),
            new DateTime(2021, 6, 19)
        };
            QuickSort.Sort(array);
            array.Should().Equal(
            new DateTime(2019, 4, 18),
            new DateTime(2020, 4, 13),
            new DateTime(2021, 6, 19),
             new DateTime(2022, 5, 1));
        }

        [Fact]
        public void SortWithRandomPerson()
        {
            var p1 = new Person("Mario", "Rossi", new DateTime(1990, 5, 20));
            var p2 = new Person("Luigi", "Verdi", new DateTime(1985, 10, 15));
            var p3 = new Person("Anna", "Bianchi", new DateTime(1995, 12, 5));
            var p4 = new Person("Anna", "Rossi", new DateTime(1993, 3, 10));

            Person[] array =
                {
               p1,
               p4,
               p3,
               p2
            };
            QuickSort.Sort(array);
            array.Should().Equal(
                p3,
                p4,
                p2,
                p1
                );
        }

        public void TestSortWithComparerByName()
        {

            var p1 = new Person("Anna", "Rossi", new DateTime(1990, 12, 25));
            var p2 = new Person("Luigi", "Bianchi", new DateTime(1985, 3, 15));
            var p3 = new Person("Mario", "Bianchi", new DateTime(1991, 2, 18));
            var p4 = new Person("Anna", "Verdi", new DateTime(1992, 7, 30));
            var p5 = new Person("Giulia", "Gialli", new DateTime(1990, 1, 25));


            Person[] array = { p1, p2, p3, p4, p5 };


            var comparer = new ComparerByName();
            BubbleSort.Sort(array, comparer);


            array.Should().Equal(p1, p4, p5, p2, p3);
        }
        [Fact]
        public void TestSortWithComparerByDateSurnameName()
        {

            var p1 = new Person("Anna", "Rossi", new DateTime(1990, 12, 25));
            var p2 = new Person("Luigi", "Bianchi", new DateTime(1985, 3, 15));
            var p3 = new Person("Mario", "Bianchi", new DateTime(1991, 2, 18));
            var p4 = new Person("Anna", "Verdi", new DateTime(1992, 7, 30));
            var p5 = new Person("Giulia", "Gialli", new DateTime(1990, 12, 25));


            Person[] array = { p1, p2, p3, p4, p5 };


            var comparer = new ComparerByDateSurnameName();
            BubbleSort.Sort(array, comparer);


            array.Should().Equal(p2, p5, p1, p3, p4);
        }
        [Fact]
        public void TestSortWithComparerByReverseSurname()
        {

            var p1 = new Person("Anna", "Rossi", new DateTime(1990, 12, 25));
            var p2 = new Person("Luigi", "Bianchi", new DateTime(1985, 3, 15));
            var p3 = new Person("Mario", "Bianchi", new DateTime(1991, 2, 18));
            var p4 = new Person("Anna", "Verdi", new DateTime(1992, 7, 30));
            var p5 = new Person("Giulia", "Gialli", new DateTime(1990, 1, 25));


            Person[] array = { p1, p2, p3, p4, p5 };


            var comparer = new ComparerByReverseSurname();
            BubbleSort.Sort(array, comparer);


            array.Should().Equal(p4, p1, p5, p2, p3);
        }
        [Fact]
        public void TestSortWithComparerByAge()
        {

            var p1 = new Person("Anna", "Rossi", new DateTime(1991, 12, 25));
            var p2 = new Person("Luigi", "Bianchi", new DateTime(1985, 3, 15));
            var p3 = new Person("Mario", "Bianchi", new DateTime(1991, 2, 18));
            var p4 = new Person("Anna", "Verdi", new DateTime(1992, 7, 30));
            var p5 = new Person("Giulia", "Gialli", new DateTime(1996, 1, 25));


            Person[] array = { p1, p2, p3, p4, p5 };


            var comparer = new ComparerByAge();
            BubbleSort.Sort(array, comparer);


            array.Should().Equal(p5, p4, p1, p3, p2);
        }
    }
}
