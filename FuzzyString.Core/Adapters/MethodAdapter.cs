using System;
using FuzzySearch.Core.Algorithms;

namespace FuzzySearch.Core
{
    internal class MethodAdapter<T> : IShortFuzzy where T : ISearchMethod, new()
    {
        public double GetRate(string arg1, string arg2, StringComparisonType compareType, StringTransmutation transmutation)
        {
            PrepareString(ref arg1, compareType);
            PrepareString(ref arg2, compareType);

            if (transmutation.HasFlag(StringTransmutation.None))
            {
                
            }

            throw new NotImplementedException();
        }

        private void PrepareString(ref string str, StringComparisonType type)
        {
            switch (type)
            {
                case StringComparisonType.Ordinal:
                    break;
                case StringComparisonType.OrdinalIgnoreCase:
                    str = str.ToLower();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("type");
            }
        }
    }
}
