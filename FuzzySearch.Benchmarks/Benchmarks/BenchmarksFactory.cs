using System.IO;
using FuzzySearch.Core;

namespace FuzzySearch.Benchmarks.Benchmarks
{
    public class BenchmarksFactory
    {
        public static BenchmarkTest[] GetTest(TextWriter sw)
        {
            var tests = new []
            {
                new BenchmarkTest(sw, "Levenshtein Distance", StringComparison.LevenshteinDistance), 
            };
            return tests;
        }
    }
}