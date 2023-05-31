// Use any one of below to trigger benchmarking on specific type or assembly

// Run benchmarking on all types in the specified assembly
using BenchmarkDotNet.Running;
using ConsoleApp;

//var summary = BenchmarkRunner.Run(typeof(Program).Assembly);

//// Run benchmarking on the specified type
//var summary = BenchmarkRunner.Run<MyBenchmarks>();

//Run benchmark on the specified type
var summary = BenchmarkRunner.Run(typeof(MyBenchmarks));
