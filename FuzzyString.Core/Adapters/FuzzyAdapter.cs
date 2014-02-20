using System;

namespace FuzzySearch.Core
{
    public class FuzzyAdapter<T>: IFuzzy where T : IShortFuzzy, new()
    {
        private T _shortFuzzy;

        public FuzzyAdapter()
        {
            _shortFuzzy = new T();
        }

        public double GetRate(string arg1, string arg2)
        {
            throw new NotImplementedException();
        }

        public double GetRate(string arg1, string arg2, StringComparisonType compareType)
        {
            throw new NotImplementedException();
        }

        public double GetRate(string arg1, string arg2, StringTransmutation transmutation)
        {
            throw new NotImplementedException();
        }

        public double GetRate(string arg1, string arg2, StringComparisonType compareType, StringTransmutation transmutation)
        {
            throw new NotImplementedException();
        }

        public bool IsEqual(string arg1, string arg2)
        {
            throw new NotImplementedException();
        }

        public bool IsEqual(string arg1, string arg2, StringComparisonType compareType)
        {
            throw new NotImplementedException();
        }

        public bool IsEqual(string arg1, string arg2, StringTransmutation transmutation)
        {
            throw new NotImplementedException();
        }

        public bool IsEqual(string arg1, string arg2, StringComparisonType compareType, StringTransmutation transmutation)
        {
            throw new NotImplementedException();
        }

        public bool IsEqual(string arg1, string arg2, double minimalRate)
        {
            throw new NotImplementedException();
        }

        public bool IsEqual(string arg1, string arg2, double minimalRate, StringComparisonType compareType)
        {
            throw new NotImplementedException();
        }

        public bool IsEqual(string arg1, string arg2, double minimalRate, StringTransmutation transmutation)
        {
            throw new NotImplementedException();
        }

        public bool IsEqual(string arg1, string arg2, double minimalRate, StringComparisonType compareType, StringTransmutation transmutation)
        {
            throw new NotImplementedException();
        }
    }
}