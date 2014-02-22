using FuzzySearch.Core;
using NUnit.Framework;

namespace FuzzySearch.Test
{
    [TestFixture]
    public class JaroWinklerDistanceTests : MethodTests
    {
        [SetUp]
        public override void Initialize()
        {
            method = StringComparison.JaroWinklerDistance;
        }
    }
}