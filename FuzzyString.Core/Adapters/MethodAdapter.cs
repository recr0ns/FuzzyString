using System;
using System.Collections.Generic;
using System.Linq;
using FuzzySearch.Core.Algorithms;
using FuzzySearch.Core.Utils;

namespace FuzzySearch.Core.Adapters
{
    internal class MethodAdapter<T> : IShortFuzzy where T : ISearchMethod, new()
    {
        private readonly ISearchMethod _method;
        private const double EqualRate = 1d - 1E-5;

        public MethodAdapter()
        {
            _method = new T();
        }

        public double GetRate(string arg1, string arg2, StringComparisonType compareType, StringTransmutation transmutation)
        {
            PrepareString(ref arg1, compareType);
            PrepareString(ref arg2, compareType);

            if (transmutation.HasFlag(StringTransmutation.None))
            {
                return _method.GetRate(arg1, arg2);
            }

            var line1 = GetLine(arg1, transmutation);
            var line2 = GetLine(arg2, transmutation);

            var maxRate = 0d;
            foreach (var rate in line1.SelectMany(l1 => line2.Select(l2 => _method.GetRate(l1, l2))))
            {
                if (rate > maxRate) maxRate = rate;
                if (maxRate > EqualRate) return maxRate;
            }
            return maxRate;
        }

        private IEnumerable<string> GetLine(string initialValue, StringTransmutation transmutation)
        {
            IList<string> line = new List<string>() { initialValue };
            if (transmutation.HasFlag(StringTransmutation.Transliteration))
            {
                AddTransliterationToLine(ref line, initialValue);
            }

            if (transmutation.HasFlag(StringTransmutation.Soundex))
            {
                AddSoundexToLine(ref line, initialValue);
            }
            return line;
        }

        private void AddTransliterationToLine(ref IList<string> line, string value)
        {
            var translit = Transliteration.Convert(value);
            if (!line.Contains(translit)) line.Add(translit);
        }

        private void AddSoundexToLine(ref IList<string> line, string value)
        {
            var soundex = Soundex.Convert(value);
            if (!line.Contains(soundex)) line.Add(soundex);
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
