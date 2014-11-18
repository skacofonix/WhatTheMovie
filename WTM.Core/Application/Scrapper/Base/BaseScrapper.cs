using System;
using System.Text.RegularExpressions;

namespace WTM.Core.Application.Scrapper.Base
{
    public abstract class BaseScrapper
    {
        private const string Host = "www.whatthemovie.com";
        protected abstract string Identifier { get; }
        protected abstract string Parameter { get; }

        protected virtual Uri MakeUri()
        {
            var uriBuilder = new UriBuilder("http", Host, 80, Identifier + "/" + Parameter);
            var uri = uriBuilder.Uri;
            return uri;
        }

        protected T TryParseElement<T>(Func<T> func)
            where T : class
        {
            T value;

            try
            {
                value = func();
            }
            catch (Exception ex)
            {
                // Log
                value = null;
            }

            return value;
        }

        protected string ExtractValue(string value, Regex regex)
        {
            var match = regex.Match(value);
            var valueExtracted = match.Groups[1].Value;

            return valueExtracted;
        }

        protected int? ExtractAndParseInt(string value, Regex regex)
        {
            var valueExctracted = ExtractValue(value, regex);

            if (string.IsNullOrWhiteSpace(valueExctracted))
                return null;

            int valueConverted;
            if (int.TryParse(valueExctracted, out valueConverted))
                return valueConverted;

            return null;
        }

        protected DateTime ExtractAndParseDateTime(string value, Regex regex)
        {
            var valueExctracted = ExtractValue(value, regex);

            DateTime valueConverted;
            DateTime.TryParse(valueExctracted, out valueConverted);

            return valueConverted;
        }
    }
}