using FuzzySearch.Core;
using NUnit.Framework;

namespace FuzzySearch.Test
{
    [TestFixture]
    public class LCSTests : MethodTests
    {
        [SetUp]
        public override void Initialize()
        {
            method = StringComparison.LongestCommonSubsequence;
        }
    }
}