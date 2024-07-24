using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SortLibBenchmark
{
    //[MemoryDiagnoser]
    [AsciiDocExporter]
    [CsvExporter]
    [HtmlExporter]
    public class SortBenchmark
    {

        private static Random rnd = new Random();

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public void QuickSort(int[] array, ArrayOrderedMode mode)
        {
            SortLib.QuickSort.QuickSort.Sort(array);
        }

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public void BubbleSort(int[] array, ArrayOrderedMode mode)
        {
            SortLib.BubbleSort.BubbleSort.Sort(array);
        }

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public void SelectionSort(int[] array, ArrayOrderedMode mode)
        {
            SortLib.SelectionSort.SelectionSort.Sort(array);
        }

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public void MergeSort(int[] array, ArrayOrderedMode mode) 
        {
            SortLib.MergeSort.MergeSort.Sort(array);
        }

        public enum ArrayOrderedMode
        {
            Random,
            Ordered,
            Reversed
        }
        public IEnumerable<object[]> Data()
        {
            int n = 100;
            yield return new object[] {Enumerable.Range(1, n).Select(i => rnd.Next(500)).ToArray(), ArrayOrderedMode.Random };

            yield return new object[] {Enumerable.Range(1, n).ToArray(), ArrayOrderedMode.Ordered };

            yield return new object[] {Enumerable.Range(1, n).Reverse().ToArray(),ArrayOrderedMode.Reversed };


            n = 1_000;
            yield return new object[] { Enumerable.Range(1, n).Select(i => rnd.Next(500)).ToArray(), ArrayOrderedMode.Random };

            yield return new object[] { Enumerable.Range(1, n).ToArray(), ArrayOrderedMode.Ordered };

            yield return new object[] { Enumerable.Range(1, n).Reverse().ToArray(), ArrayOrderedMode.Reversed };

            n = 10_000;
            yield return new object[] { Enumerable.Range(1, n).Select(i => rnd.Next(500)).ToArray(), ArrayOrderedMode.Random };

            yield return new object[] { Enumerable.Range(1, n).ToArray(), ArrayOrderedMode.Ordered };

            yield return new object[] { Enumerable.Range(1, n).Reverse().ToArray(), ArrayOrderedMode.Reversed };

        }
    }
}
