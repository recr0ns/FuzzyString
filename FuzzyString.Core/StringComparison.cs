using System;
using FuzzySearch.Core.Adapters;
using FuzzySearch.Core.Algorithms;

namespace FuzzySearch.Core
{
    public sealed class StringComparison
    {
        private static readonly Lazy<IFuzzy> _levenshtein = new Lazy<IFuzzy>(ConstructorHelper<FuzzyAdapter<MethodAdapter<LevenshteinDistanceMethod>>>.Build);
        public static IFuzzy LevenshteinDistance { get { return _levenshtein.Value; } }

        private StringComparison()
        { }
    }
}