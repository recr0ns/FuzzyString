using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace FuzzySearch.PhoneticAlgorithms
{
    public class Soundex
    {
        private static readonly char[] IgnoredSymbols = { 'A', 'O', 'U', 'E', 'I', 'Y', 'H', 'W' };
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
            input = SoundexUtils.Clean(input);
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
                {'B', '1'},
                {'P', '1'},
                {'F', '1'},
                {'V', '1'},
                {'C', '2'},
                {'S', '2'},
                {'K', '2'},
                {'J', '2'},
                {'G', '2'},
                {'Q', '2'},
                {'X', '2'},
                {'Z', '2'},
                {'D', '3'},
                {'T', '3'},
                {'L', '4'},
                {'M', '5'},
                {'N', '5'},
                {'R', '6'}
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
                {'B', '1'},
                {'P', '1'},
                {'F', '2'},
                {'V', '2'},
                {'C', '3'},
                {'S', '3'},
                {'K', '3'},
                {'J', '4'},
                {'G', '4'},
                {'Q', '5'},
                {'X', '5'},
                {'Z', '5'},
                {'D', '6'},
                {'T', '6'},
                {'L', '7'},
                {'M', '8'},
                {'N', '8'},
                {'R', '9'}
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