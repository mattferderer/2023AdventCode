using BenchmarkDotNet.Running;
using BenchmarkDotNet.Attributes;

var summary = BenchmarkRunner
    .Run(typeof(Program).Assembly);