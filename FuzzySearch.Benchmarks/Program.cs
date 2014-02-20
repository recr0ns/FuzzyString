using System;
using FuzzySearch.Benchmarks.Benchmarks;

namespace FuzzySearch.Benchmarks
{
    class Program
    {
        static void Main()
        {
            // if u want write to file create another TextWriter
            using (var sw = Console.Out)
            {
                var tests = BenchmarksFactory.GetTest(sw);
                Array.ForEach(tests, test => test.Action());
            }
            Console.ReadKey();
        }
    }
}
