namespace FuzzySearch.Core
{
    public interface IShortFuzzy
    {
        double GetRate(string arg1, string arg2, StringComparisonType compareType, StringTransmutation transmutation);
    }
}