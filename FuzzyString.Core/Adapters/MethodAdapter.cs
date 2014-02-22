using System;
using FuzzySearch.Core.Algorithms;

namespace FuzzySearch.Core.Adapters
{
    internal class MethodAdapter<T> : IShortFuzzy where T : ISearchMethod, new()
    {
        private readonly ISearchMethod _method;

        public MethodAdapter()
        {
            _method = new T();
        }

        public double GetRate(string arg1, string arg2, StringComparisonType compareType, StringTransmutation transmutation)
        {
            PrepareString(ref arg1, compareType);
            PrepareString(ref arg2, compareType);

            arg1 = StringFormatter.Convert(arg1, transmutation);
            arg2 = StringFormatter.Convert(arg2, transmutation);

            return _method.GetRate(arg1, arg2);
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
