using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Benchmarks.DataImportWorkerService.Benchmarks;

/// <results>
/// UseReplaceInArray is significantly faster than UsePointers (3x faster). It wins by replacing the words in the first read. This allows the search for first to start at the begginning of the line & stop on the first occurance. The search for last starts at the end of the line & stops on the first occurance. This prevents a search for each word number (9 loops using every character in the line)
/// BenchmarkDotNet=v0.13.1
/// | Method            | Mean       | Error    | StdDev   |
/// |------------------ |-----------:|---------:|---------:|
/// | UseReplaceInArray |   402.4 us |  8.02 us | 10.14 us |
/// | UsePointers       | 1,225.7 us | 14.57 us | 13.63 us |
/// * Legends *
///   Mean   : Arithmetic mean of all measurements
///   Error  : Half of 99.9% confidence interval
///   StdDev : Standard deviation of all measurements
///   1 us   : 1 Microsecond (0.000001 sec)
/// </results>

public class Day1Benchmarks
{
    public Day1Benchmarks()
    {
    }

    [Benchmark]
    public int UseReplaceInArray()
    {
        var parser = new Day1("Day1Input.txt");
        return parser.UseReplaceInArray();
    }

    [Benchmark]
    public int UsePointers()
    {
        var parser = new Day1("Day1Input.txt");
        return parser.UsePointers();
    }
}