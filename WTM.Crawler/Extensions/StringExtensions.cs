using System.Text.RegularExpressions;

namespace WTM.Crawler.Extensions
{
    internal static class StringExtensions
    {
        public static string ExtractValue(this string value, Regex regex)
        {
            var match = regex.Match(value);
            var valueExtracted = match.Groups[1].Value;
            return valueExtracted;
        }

        public static int? ExtractAndParseInt(this string value, Regex regex)
        {
            var valueExctracted = ExtractValue(value, regex);

            if (string.IsNullOrWhiteSpace(valueExctracted))
                return null;

            int valueConverted;
            if (int.TryParse(valueExctracted, out valueConverted))
                return valueConverted;

            return null;
        }

        public static string CleanString(this string s)
        {
            return Regex.Replace(s, @"[\t\r\n\f]*", string.Empty);
        }
    }
}
