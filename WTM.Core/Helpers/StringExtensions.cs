using System;
using System.Text.RegularExpressions;

namespace WTM.Core.Helpers
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

        public static DateTime ExtractAndParseDateTime(this string value, Regex regex)
        {
            var valueExctracted = ExtractValue(value, regex);

            DateTime valueConverted;
            DateTime.TryParse(valueExctracted, out valueConverted);

            return valueConverted;
        }

        public static string CleanString(this string s)
        {
            return Regex.Replace(s, @"[\r\t\n]", string.Empty);
        }
    }
}
