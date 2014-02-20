namespace FuzzySearch.Core
{
    public interface IFuzzy
    {
        double GetRate(string arg1, string arg2);
        double GetRate(string arg1, string arg2, StringComparisonType compareType);
        double GetRate(string arg1, string arg2, StringTransmutation transmutation);
        double GetRate(string arg1, string arg2, StringComparisonType compareType, StringTransmutation transmutation);

        bool IsEqual(string arg1, string arg2);
        bool IsEqual(string arg1, string arg2, StringComparisonType compareType);
        bool IsEqual(string arg1, string arg2, StringTransmutation transmutation);
        bool IsEqual(string arg1, string arg2, StringComparisonType compareType, StringTransmutation transmutation);
        bool IsEqual(string arg1, string arg2, double minimalRate);
        bool IsEqual(string arg1, string arg2, double minimalRate, StringComparisonType compareType);
        bool IsEqual(string arg1, string arg2, double minimalRate, StringTransmutation transmutation);
        bool IsEqual(string arg1, string arg2, double minimalRate, StringComparisonType compareType, StringTransmutation transmutation);
    }
}