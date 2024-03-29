﻿using System.IO;
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
                new BenchmarkTest(sw, "Dice Coefficient", StringComparison.DiceCoefficient), 
                new BenchmarkTest(sw, "Longest Common Subsequence", StringComparison.LongestCommonSubsequence), 
                new BenchmarkTest(sw, "Jaro Winkler Distance", StringComparison.JaroWinklerDistance), 
            };
            return tests;
        }
    }
}