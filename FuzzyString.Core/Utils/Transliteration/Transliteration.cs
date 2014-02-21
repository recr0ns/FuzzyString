using System.Collections;
using System.Text;

namespace FuzzySearch.Core.Utils.Transliteration
{
    public static class Transliteration
    {
        public static string Convert(string input, ITransliterationLanguage lang)
        {
            var sb = new StringBuilder();
            foreach (var ch in input)
            {
                var translated = (string)lang.GetAlphabet()[ch];
                if (translated == null)
                {
                    sb.Append(ch);
                }
                else
                {
                    sb.Append(translated);
                }
            }
            return sb.ToString();
        }
    }

    public interface ITransliterationLanguage
    {
        Hashtable GetAlphabet();
    }

    public class RussianTransliteration : ITransliterationLanguage
    {
        private readonly Hashtable _table;
        public static ITransliterationLanguage Create()
        {
            return new RussianTransliteration();
        }

        public RussianTransliteration()
        {
            _table = new Hashtable
            {
                {'а', "a"},
                {'б', "b"},
                {'в', "v"},
                {'г', "g"},
                {'д', "d"},
                {'е', "e"},
                {'ё', "e"},
                {'ж', "j"},
                {'з', "z"},
                {'и', "i"},
                {'й', "y"},
                {'к', "k"},
                {'л', "l"},
                {'м', "m"},
                {'н', "n"},
                {'о', "o"},
                {'п', "p"},
                {'р', "r"},
                {'с', "s"},
                {'т', "t"},
                {'у', "u"},
                {'ф', "f"},
                {'х', "h"},
                {'ц', "c"},
                {'ч', "ch"},
                {'ш', "sh"},
                {'щ', "sch"},
                {'ъ', "\""},
                {'ы', "i"},
                {'ь', "\'"},
                {'э', "e"},
                {'ю', "u"},
                {'я', "ya"},
                {'А', "A"},
                {'Б', "B"},
                {'В', "V"},
                {'Г', "G"},
                {'Д', "D"},
                {'Е', "E"},
                {'Ё', "E"},
                {'Ж', "J"},
                {'З', "Z"},
                {'И', "I"},
                {'Й', "Y"},
                {'К', "K"},
                {'Л', "L"},
                {'М', "M"},
                {'Н', "N"},
                {'О', "O"},
                {'П', "P"},
                {'Р', "R"},
                {'С', "S"},
                {'Т', "T"},
                {'У', "U"},
                {'Ф', "F"},
                {'Х', "H"},
                {'Ц', "C"},
                {'Ч', "Ch"},
                {'Ш', "Sh"},
                {'Щ', "Sch"},
                {'Ъ', "\""},
                {'Ы', "I"},
                {'Ь', "\'"},
                {'Э', "E"},
                {'Ю', "U"},
                {'Я', "Ya"}
            };
        }

        public Hashtable GetAlphabet()
        {
            return _table;
        }
    }
}