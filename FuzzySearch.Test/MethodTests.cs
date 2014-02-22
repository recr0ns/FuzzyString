using FuzzySearch.Core;
using NUnit.Framework;

namespace FuzzySearch.Test
{
    public abstract class MethodTests
    {
        protected IFuzzy method;

        public abstract void Initialize();

        [TestCase]
        public void RateIsOneForSameString()
        {
            const string str = "Hello";
            Assert.That(method.GetRate(str, str), Is.EqualTo(1d));
        }

        [TestCase("Hello")]
        public void RateIsZeroForEmptyString(string arg1)
        {
            Assert.That(method.GetRate(arg1, string.Empty), Is.EqualTo(0));
        }

        [TestCase("hello", "Hello")]
        public void RateIsOneForSameStringWithIgnoreCase(string arg1, string arg2)
        {
            Assert.That(
                method.GetRate(arg1, arg2, StringComparisonType.OrdinalIgnoreCase),
                Is.EqualTo(1d));
        }

        [TestCase("Wood", "Stone")]
        [TestCase("Hell", "Hello")]
        [TestCase("Red", "White")]
        public void RateBetweenOneAndZeroForDiffirentStrings(string arg1, string arg2)
        {
            Assert.That(method.GetRate(arg1, arg2), Is.GreaterThanOrEqualTo(0d));
            Assert.That(method.GetRate(arg1, arg2), Is.LessThanOrEqualTo(1d));
        }

        [TestCase("Hello")]
        public void StringAreEqualsToYourself(string arg)
        {
            Assert.That(method.IsEqual(arg, arg), Is.True);
        }

        [TestCase("Hello", "hello")]
        [TestCase("Hello", "HeLlO")]
        public void StringAreEqualsIgnoreCase(string arg1, string arg2)
        {
            Assert.That(method.IsEqual(arg1, arg2, StringComparisonType.OrdinalIgnoreCase), Is.True);
        }
    }
}