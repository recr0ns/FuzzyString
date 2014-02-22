using System;
using FuzzySearch.Core.Utils.Transliteration;
using FuzzySearch.PhoneticAlgorithms;

namespace FuzzySearch.Core
{
    internal static class StringFormatter
    {
        public static string Convert(string input, StringTransmutation transmutationType)
        {
            switch (transmutationType)
            {
                case StringTransmutation.None:
                    return input;
                case StringTransmutation.Transliteration:
                    return Transliteration.Convert(input, RussianTransliteration.Create());
                case StringTransmutation.Soundex:
                    return Soundex.Convert(input, SoundexType.Simple);
                case StringTransmutation.ImprovedSoundex:
                    return Soundex.Convert(input, SoundexType.Improved);
                case StringTransmutation.NYSIIS:
                    return NYSIIS.Convert(input);
                default:
                    throw new ArgumentOutOfRangeException("transmutationType");
            }
        }
    }
}