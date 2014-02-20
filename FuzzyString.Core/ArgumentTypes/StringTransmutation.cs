using System;

namespace FuzzySearch.Core
{
    [Flags]
    public enum StringTransmutation
    {
        None = 1 << 0,
        Transliteration = 1 << 1,
        Soundex = 1 << 2
    }
}