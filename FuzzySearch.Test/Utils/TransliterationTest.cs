using FuzzySearch.Core.Utils.Transliteration;
using NUnit.Framework;

namespace FuzzySearch.Test.Utils
{
    [TestFixture]
    public class TransliterationTest
    {
        [TestCase("Hello", "Hello")]
        [TestCase("Хелло", "Hello")]
        [TestCase("Hелло", "Hello")]
        [TestCase("Щавель", "Schavel\'")]
        public void RussianTransliterationTest(string input, string output)
        {
            Assert.That(Transliteration.Convert(input, RussianTransliteration.Create()), Is.EqualTo(output));
        }
    }
}