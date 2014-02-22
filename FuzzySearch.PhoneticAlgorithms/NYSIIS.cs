using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FuzzySearch.PhoneticAlgorithms
{
    public class NYSIIS
    {
        private static readonly char[] CHARS_A = { 'A' };
        private static readonly char[] CHARS_AF = { 'A', 'F' };
        private static readonly char[] CHARS_C = { 'C' };
        private static readonly char[] CHARS_FF = { 'F', 'F' };
        private static readonly char[] CHARS_G = { 'G' };
        private static readonly char[] CHARS_N = { 'N' };
        private static readonly char[] CHARS_NN = { 'N', 'N' };
        private static readonly char[] CHARS_S = { 'S' };
        private static readonly char[] CHARS_SSS = { 'S', 'S', 'S' };

        private const string PATTERN_MAC = "^MAC";
        private const string PATTERN_KN = "^KN";
        private const string PATTERN_K = "^K";
        private const string PATTERN_PH_PF = "^(PH|PF)";
        private const string PATTERN_SCH = "^SCH";

        private const string PATTERN_EE_IE = "(EE|IE)$";
        private const string PATTERN_DT_ETC = "(DT|RT|RD|NT|ND)$";

        private const char SPACE = ' ';

        private static readonly char[] vowels = new[] { 'a', 'e', 'i', 'o', 'u' };
        private static StringBuilder TransformMiddle(StringBuilder sb)
        {
            var data = new Hashtable()
            {
                {"ev", "af"},
                {"q", "g"},
                {"z", "s"},
                {"m", "n"},
                {"kn", "n"},
                {"k", "c"},
                {"sch", "sss"},
                {"ph", "ff"}
            };
            var len = sb.Length - 1;
            Array.ForEach(vowels, v => sb = sb.Replace(v, 'a', 1, len));
            sb = data.Keys.Cast<object>()
                .Aggregate(sb,
                    (current, key) =>
                        current.Replace((string)key, (string)data[key], 1, len));
            for (var i = 0; i < sb.Length; ++i)
            {
                var isVowel = false;
                while (vowels.Contains(sb[i]))
                {
                    isVowel = true;
                    i++;
                }
                if (isVowel)
                {
                    sb = sb.Replace("h", "", i, 1);
                    if (sb[i] == 'w')
                    {
                        sb[i] = 'a';
                        i--;
                    }

                }
            }
            return sb;
        }

        private static bool IsVowel(char c)
        {
            return c == 'A' || c == 'E' || c == 'I' || c == 'O' || c == 'U';
        }

        // http://commons.apache.org/proper/commons-codec/apidocs/src-html/org/apache/commons/codec/language/Nysiis.html#line.70
        // Line : 118
        private static char[] TranscodeRemaining(char prev, char curr, char next, char aNext)
        {
            // 1. EV -> AF
            if (curr == 'E' && next == 'V')
            {
                return CHARS_AF;
            }

            // A, E, I, O, U -> A
            if (IsVowel(curr))
            {
                return CHARS_A;
            }

            // 2. Q -> G, Z -> S, M -> N
            if (curr == 'Q')
            {
                return CHARS_G;
            }
            else if (curr == 'Z')
            {
                return CHARS_S;
            }
            else if (curr == 'M')
            {
                return CHARS_N;
            }

            // 3. KN -> NN else K -> C
            if (curr == 'K')
            {
                return next == 'N' ? CHARS_NN : CHARS_C;
            }

            // 4. SCH -> SSS
            if (curr == 'S' && next == 'C' && aNext == 'H')
            {
                return CHARS_SSS;
            }

            // PH -> FF
            if (curr == 'P' && next == 'H')
            {
                return CHARS_FF;
            }

            // 5. H -> If previous or next is a non vowel, previous.
            if (curr == 'H' && (!IsVowel(prev) || !IsVowel(next)))
            {
                return new [] { prev };
            }

            // 6. W -> If previous is vowel, previous.
            if (curr == 'W' && IsVowel(prev))
            {
                return new [] { prev };
            }

            return new [] { curr };
        }

        public static string Convert(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return input;

            input = SoundexUtils.Clean(input);
            /*
             * MAC → MCC
             * KN → N
             * K → C
             * PH, PF → FF
             * SCH → SSS 
             */
            input = Regex.Replace(input, PATTERN_MAC, "MCC");
            input = Regex.Replace(input, PATTERN_KN, "N");
            input = Regex.Replace(input, PATTERN_K, "C");
            input = Regex.Replace(input, PATTERN_PH_PF, "FF");
            input = Regex.Replace(input, PATTERN_SCH, "SCC");

            /*
             * EE → Y
             * IE → Y
             * DT, RT, RD, NT, ND → D
             */
            input = Regex.Replace(input, PATTERN_EE_IE, "Y");
            input = Regex.Replace(input, PATTERN_DT_ETC, "D");

            var sb = new StringBuilder(input.Length);
            sb.Append(input[0]);

            var chars = input.ToCharArray();
            var len = chars.Length;

            for (var i = 1; i < len; i++)
            {
                var next = i < len - 1 ? chars[i + 1] : SPACE;
                var aNext = i < len - 2 ? chars[i + 2] : SPACE;
                var transcoded = TranscodeRemaining(chars[i - 1], chars[i], next, aNext);

                Array.Copy(transcoded, 0, chars, i, transcoded.Length);

                // only append the current char to the key if it is different from the last one
                if (chars[i] != chars[i - 1])
                {
                    sb.Append(chars[i]);
                }
            }

            if (sb.Length > 1)
            {
                char lastChar = sb[sb.Length - 1];

                // If last character is S, remove it.
                if (lastChar == 'S')
                {
                    sb.Remove(sb.Length - 1, 1);
                    lastChar = sb[sb.Length - 1];
                }

                if (sb.Length > 2)
                {
                    var last2Char = sb[sb.Length - 2];
                    // If last characters are AY, replace with Y.
                    if (last2Char == 'A' && lastChar == 'Y')
                    {
                        sb.Remove(sb.Length - 2, 1);
                    }
                }

                // If last character is A, remove it.
                if (lastChar == 'A')
                {
                    sb.Remove(sb.Length - 1, 1);
                }
            }

            return sb.ToString();
        }
    }
}