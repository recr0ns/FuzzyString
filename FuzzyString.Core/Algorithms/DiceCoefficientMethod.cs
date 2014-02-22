using System.Collections.Generic;

namespace FuzzySearch.Core.Algorithms
{
    internal class DiceCoefficientMethod : ISearchMethod
    {
        private static HashSet<string> GetBigramms(string input)
        {
            var bigramms = new HashSet<string>();
            for (var i = 0; i < input.Length - 1; i++)
            {
                bigramms.Add(input.Substring(i, 2));
            }
            return bigramms;
        }

        private static double ComputeDiceCoefficient(string arg1, string arg2)
        {
            var nx = GetBigramms(arg1);
            var ny = GetBigramms(arg2);
            
            var intersection = new HashSet<string>(nx);
            intersection.IntersectWith(ny);

            double dbOne = intersection.Count;
            return (2 * dbOne) / (nx.Count + ny.Count);
        }

        public double GetRate(string arg1, string arg2)
        {
            return ComputeDiceCoefficient(arg1, arg2);
        }
    }
}