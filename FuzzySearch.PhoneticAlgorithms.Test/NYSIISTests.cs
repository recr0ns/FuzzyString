using NUnit.Framework;

namespace FuzzySearch.PhoneticAlgorithms.Test
{
    [TestFixture]
    public class NYSIISTests
    {
        [TestCase("bishop", "BASAP")]
        [TestCase("lawrence","LARANC")]
        public void TransformTest(string input, string output)
        {
            Assert.That(NYSIIS.Convert(input), Is.EqualTo(output));
        }
         
    }
}