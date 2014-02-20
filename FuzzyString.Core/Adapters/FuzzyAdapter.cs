namespace FuzzySearch.Core.Adapters
{
    public class FuzzyAdapter<T>: IFuzzy where T : IShortFuzzy, new()
    {
        private readonly T _shortFuzzy;
        private const double EqualRate = 0.99d;

        public FuzzyAdapter()
        {
            _shortFuzzy = new T();
        }

        public double GetRate(string arg1, string arg2)
        {
            return GetRate(arg1, arg2, StringComparisonType.Ordinal, StringTransmutation.None);
        }

        public double GetRate(string arg1, string arg2, StringComparisonType compareType)
        {
            return GetRate(arg1, arg2, compareType, StringTransmutation.None);
        }

        public double GetRate(string arg1, string arg2, StringTransmutation transmutation)
        {
            return GetRate(arg1, arg2, StringComparisonType.Ordinal, transmutation);
        }

        public double GetRate(string arg1, string arg2, StringComparisonType compareType, StringTransmutation transmutation)
        {
            return _shortFuzzy.GetRate(arg1, arg2, compareType, transmutation);
        }

        public bool IsEqual(string arg1, string arg2)
        {
            return IsEqual(arg1, arg2, StringComparisonType.Ordinal, StringTransmutation.None);
        }

        public bool IsEqual(string arg1, string arg2, StringComparisonType compareType)
        {
            return IsEqual(arg1, arg2, compareType, StringTransmutation.None);
        }

        public bool IsEqual(string arg1, string arg2, StringTransmutation transmutation)
        {
            return IsEqual(arg1, arg2, StringComparisonType.Ordinal, transmutation);
        }

        public bool IsEqual(string arg1, string arg2, StringComparisonType compareType, StringTransmutation transmutation)
        {
            return IsEqual(arg1, arg2, EqualRate, compareType, transmutation);
        }

        public bool IsEqual(string arg1, string arg2, double minimalRate)
        {
            return IsEqual(arg1, arg2, minimalRate, StringComparisonType.Ordinal, StringTransmutation.None);
        }

        public bool IsEqual(string arg1, string arg2, double minimalRate, StringComparisonType compareType)
        {
            return IsEqual(arg1, arg2, minimalRate, compareType, StringTransmutation.None);
        }

        public bool IsEqual(string arg1, string arg2, double minimalRate, StringTransmutation transmutation)
        {
            return IsEqual(arg1, arg2, minimalRate, StringComparisonType.Ordinal, transmutation);
        }

        public bool IsEqual(string arg1, string arg2, double minimalRate, StringComparisonType compareType, StringTransmutation transmutation)
        {
            if (minimalRate < 1E-5)  return true;
            return GetRate(arg1, arg2, compareType, transmutation) > minimalRate;
        }
    }
}