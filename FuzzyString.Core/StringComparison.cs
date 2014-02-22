using System;
using FuzzySearch.Core.Adapters;
using FuzzySearch.Core.Algorithms;

namespace FuzzySearch.Core
{
    public sealed class StringComparison
    {
        private static readonly Lazy<IFuzzy> _levenshtein = new Lazy<IFuzzy>(ConstructorHelper<FuzzyAdapter<MethodAdapter<LevenshteinDistanceMethod>>>.Build);
        private static readonly Lazy<IFuzzy> _dice = new Lazy<IFuzzy>(ConstructorHelper<FuzzyAdapter<MethodAdapter<DiceCoefficientMethod>>>.Build); 
        private static readonly Lazy<IFuzzy> _lcs = new Lazy<IFuzzy>(ConstructorHelper<FuzzyAdapter<MethodAdapter<LongestCommonSubsequenceMethod>>>.Build);
        private static readonly Lazy<IFuzzy> _jwd = new Lazy<IFuzzy>(ConstructorHelper<FuzzyAdapter<MethodAdapter<JaroWinklerDistanceMethod>>>.Build); 

        public static IFuzzy LevenshteinDistance { get { return _levenshtein.Value; } }
        public static IFuzzy DiceCoefficient { get { return _dice.Value; } }
        public static IFuzzy LongestCommonSubsequence { get { return _lcs.Value; } }
        public static IFuzzy JaroWinklerDistance { get { return _jwd.Value; } }
        private StringComparison()
        { }
    }
}