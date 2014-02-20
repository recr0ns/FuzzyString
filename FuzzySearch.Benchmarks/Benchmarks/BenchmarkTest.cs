using System;
using System.IO;
using FuzzySearch.Core;

namespace FuzzySearch.Benchmarks.Benchmarks
{
    // Using data from :
    // http://www.tsjensen.com/blog/post/2011/05/27/Four+Functions+For+Finding+Fuzzy+String+Matches+In+C+Extensions.aspx
    public class BenchmarkTest
    {
        private const string Name = "Jnsen";

        private static readonly string[] NamesList = new string[]
        {
            "Adams",
            "Benson",
            "Geralds",
            "Johannson",
            "Johnson",
            "Jensen",
            "Jordon",
            "Madsen",
            "Stratford",
            "Wilkins"
        };

        private const string Address = "2130 South Fort Union Blvd.";

        private static readonly string[] AddressList = new string[]
        {
            "2689 East Milkin Ave.",
            "85 Morrison",
            "2350 North Main",
            "567 West Center Street",
            "2130 Fort Union Boulevard",
            "2310 S. Ft. Union Blvd.",
            "98 West Fort Union",
            "Rural Route 2 Box 29",
            "PO Box 3487",
            "3 Harvard Square",
        };

        private TextWriter sw;
        private string _methodName;
        private IFuzzy _method;

        public BenchmarkTest(TextWriter sw, string methodName, IFuzzy method)
        {
            this.sw = sw;
            _methodName = methodName;
            _method = method;
        }

        public void Action()
        {
            sw.WriteLine("Tests for method : {0}", _methodName);
            sw.WriteLine();
            NameRateTest();
            AddressRateTest();
        }

        private void NameRateTest()
        {
            sw.WriteLine("Name Matching for : \'{0}\'", Name);
            ArrayTest(NamesList, Name, StringComparisonType.Ordinal);
            sw.WriteLine();
        }

        private void AddressRateTest()
        {
            sw.WriteLine("Address Matching for : \'{0}\'", Address);
            ArrayTest(AddressList, Address, StringComparisonType.Ordinal);
            sw.WriteLine();
        }
        

        private void ArrayTest(string[] dataArray, string searchValue, StringComparisonType compareType)
        {
            Array.ForEach(dataArray,
                name =>
                    sw.WriteLine("{0:0.00000} arainst \'{1}\'", _method.GetRate(searchValue, name, compareType), name));
        }

    }
}