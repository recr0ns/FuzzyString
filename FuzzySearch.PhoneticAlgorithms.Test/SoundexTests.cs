using System;
using NUnit.Framework;

namespace FuzzySearch.PhoneticAlgorithms.Test
{
    [TestFixture]
    public class SoundexTests
    {
        [TestCase("Azuron", "A265")]
        [TestCase("Ackermann", "A265")]
        [TestCase("Nagimov", "N251")]
        [TestCase("Nesmeev","N251")]
        [TestCase("As", "A200")]
        public void SimpleSoundexTest(string input, string code)
        {
            Assert.That(Soundex.Convert(input, SoundexType.Simple), Is.EqualTo(code));
        }

        [TestCase("Nasimov","N382")]
        [TestCase("Nazimov","N582")]
        [TestCase("Nisenbaum", "N3818")]
        [TestCase("As", "A3")]
        
        public void ImprovedSoundexTest(string input, string code)
        {
            Assert.That(Soundex.Convert(input, SoundexType.Improved), Is.EqualTo(code));
        }
    }
}
