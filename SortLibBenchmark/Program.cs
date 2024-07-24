// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using SortLibBenchmark;

var summary = BenchmarkRunner.Run<SortBenchmark>();
