using System;

namespace FuzzySearch.Core.Algorithms
{
    internal class LevenshteinDistanceMethod : ISearchMethod
    {
        private static int ComputeLevenshteinDistance(string s, string t)
        {
            var n = s.Length;
            var m = t.Length;
            var d = new int[n + 1, m + 1];

            // Step 1
            if (n == 0) { return m; }
            if (m == 0) { return n; }

            // Step 2
            for (var i = 0; i <= n; d[i, 0] = i++) { }
            for (var j = 0; j <= m; d[0, j] = j++) { }

            // Step 3
            for (var i = 1; i <= n; i++)
            {
                //Step 4
                for (var j = 1; j <= m; j++)
                {
                    // Step 5
                    var cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

                    // Step 6
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            // Step 7
            return d[n, m];
        }

        public double GetRate(string arg1, string arg2)
        {
            var maxLength = Math.Max(arg1.Length, arg2.Length);
            if (maxLength == 0) return 0d;
            var rate = (double)(maxLength - ComputeLevenshteinDistance(arg1, arg2)) / maxLength;
            return rate;
        }
    }
}