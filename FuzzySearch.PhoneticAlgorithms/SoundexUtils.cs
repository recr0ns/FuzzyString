namespace FuzzySearch.PhoneticAlgorithms
{
    // http://commons.apache.org/proper/commons-codec/xref/org/apache/commons/codec/language/SoundexUtils.html
    public class SoundexUtils
    {
        public static string Clean(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }
            var len = str.Length;
            var chars = new char[len];
            var count = 0;
            for (var i = 0; i < len; i++)
            {
                if (char.IsLetter(str[i]))
                {
                    chars[count++] = str[i];
                }
            }
            if (count == len)
            {
                return str.ToUpper();
            }
            return new string(chars, 0, count).ToUpper();
        } 
    }
}