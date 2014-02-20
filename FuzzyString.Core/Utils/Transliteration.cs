using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace FuzzySearch.Core.Utils
{
    public static class Transliteration
    {
        static Transliteration()
        {
            Alphabets = new Collection<ITransliterationAlphabet>();
        }
        public static IList<ITransliterationAlphabet> Alphabets;

        public static void SetAlphabets(params ITransliterationAlphabet[] alphabets)
        {
            Alphabets.Clear();
            Array.ForEach(alphabets, a => Alphabets.Add(a));
        }

        public static string Convert(string arg)
        {
            return Convert(arg, Alphabets.ToArray());
        }

        public static string Convert(string arg, params ITransliterationAlphabet[] alphabets)
        {
            return arg;
        }
    }

    public interface ITransliterationAlphabet
    {
        Hashtable[] GetAlphabet();
    }
}