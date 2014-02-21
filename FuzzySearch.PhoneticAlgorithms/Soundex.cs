using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace FuzzySearch.PhoneticAlgorithms
{
    public class Soundex
    {
        private static readonly char[] IgnoredSymbols = { 'a', 'o', 'u', 'e', 'i', 'y', 'h', 'w' };
        public static string Convert(string input)
        {
            return Convert(input, SoundexType.Simple);
        }

        public static string Convert(string input, SoundexType type)
        {
            ISoundexRule rule;
            switch (type)
            {
                case SoundexType.Simple:
                    rule = SimpleSoundex.Create();
                    break;
                case SoundexType.Improved:
                    rule = ImprovedSoundex.Create();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("type");
            }
            return Convert(input, rule);
        }

        public static string Convert(string input, ISoundexRule rule)
        {
            if (string.IsNullOrWhiteSpace(input) || input.Length <= 1) return input;
            var sb = new StringBuilder();
            sb.Append(input[0]);
            input = input.ToLower();
            var prevCh = input[0];
            var lastCode = '\0';
            for (int index = 1, l = 1; index < input.Length; ++index)
            {
                var currCh = input[index];
                if (!IgnoredSymbols.Contains(currCh) && currCh != prevCh)
                {
                    var code = rule.GetTable()[currCh] as char?;

                    if (code.HasValue && code != lastCode)
                    {
                        sb.Append(code.Value);
                        lastCode = code.Value;
                        l++;
                        if (rule.GetFixedLength() != 0 && l >= rule.GetFixedLength()) break;
                    }
                    else if (!code.HasValue)
                    {
                        sb.Append(currCh);
                    }

                    prevCh = currCh;
                }
            }
            if (rule.GetFixedLength() != 0 && sb.Length <= rule.GetFixedLength())
            {
                for (var i = sb.Length + 1; i <= rule.GetFixedLength(); ++i) sb.Append("0");
            }
            return sb.ToString();
        }
    }

    public enum SoundexType
    {
        Simple,
        Improved
    }

    public interface ISoundexRule
    {
        Hashtable GetTable();
        int GetFixedLength();
    }

    internal class SimpleSoundex : ISoundexRule
    {
        private Hashtable _table;

        public SimpleSoundex()
        {
            _table = new Hashtable()
            {
                {'b', '1'},
                {'p', '1'},
                {'f', '1'},
                {'v', '1'},
                {'c', '2'},
                {'s', '2'},
                {'k', '2'},
                {'j', '2'},
                {'g', '2'},
                {'q', '2'},
                {'x', '2'},
                {'z', '2'},
                {'d', '3'},
                {'t', '3'},
                {'l', '4'},
                {'m', '5'},
                {'n', '5'},
                {'r', '6'}
            };
        }

        public static ISoundexRule Create()
        {
            return new SimpleSoundex();
        }

        public Hashtable GetTable()
        {
            return _table;
        }

        public int GetFixedLength()
        {
            return 4;
        }
    }

    internal class ImprovedSoundex : ISoundexRule
    {
        private Hashtable _table;

        public ImprovedSoundex()
        {
            _table = new Hashtable()
            {
                {'b', '1'},
                {'p', '1'},
                {'f', '2'},
                {'v', '2'},
                {'c', '3'},
                {'s', '3'},
                {'k', '3'},
                {'j', '4'},
                {'g', '4'},
                {'q', '5'},
                {'x', '5'},
                {'z', '5'},
                {'d', '6'},
                {'t', '6'},
                {'l', '7'},
                {'m', '8'},
                {'n', '8'},
                {'r', '9'}
            };
        }

        public static ISoundexRule Create()
        {
            return new ImprovedSoundex();
        }

        public Hashtable GetTable()
        {
            return _table;
        }

        public int GetFixedLength()
        {
            return 0;
        }
    }
}