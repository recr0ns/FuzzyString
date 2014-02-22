using FuzzySearch.Core;
using NUnit.Framework;

namespace FuzzySearch.Test
{
    [TestFixture]
    public class DiceCoefficientTests : MethodTests
    {
        [SetUp]
        public override void Initialize()
        {
            method = StringComparison.DiceCoefficient;
        }
    }
}