

using BenchmarkDotNet.Running;
using BenckmarkApp;

Console.WriteLine("tu sam");
var summary = BenchmarkRunner.Run<DiplomskiRadBenchmark>();
Console.WriteLine(summary.ToString());
Console.ReadKey();
