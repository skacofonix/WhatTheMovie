using HtmlAgilityPack;
using System;
using System.Reflection;
using System.Text.RegularExpressions;
using WTM.Core.Application.Attributes;
using WTM.Core.Domain.WebsiteEntities.Base;

namespace WTM.Core.Application.Scrapper.Base
{
    public abstract class ScrapperT<T> where T : IWebsiteEntityBase, new()
    {
        protected readonly IWebClient WebClient;
        protected readonly IHtmlParser HtmlParser;
        protected HtmlDocument Document;

        protected abstract string Identifier { get; }
        private string parameter;
        protected T Instance { get; private set; }

        protected ScrapperT(IWebClient webClient, IHtmlParser htmlParser, string parameter = null)
        {
            WebClient = webClient;
            HtmlParser = htmlParser;
            this.parameter = parameter;
            Instance = ParseAndScrappe();
        }

        public T ParseAndScrappe()
        {
            var uri = MakeUri();
            using (var stream = WebClient.GetStream(uri))
            {
                Document = HtmlParser.GetHtmlDocument(stream);
            }
            return Scrappe();
        }

        protected virtual Uri MakeUri()
        {
            return new Uri(WebClient.UriBase, Identifier + "/" + parameter);
        }

        protected virtual T Scrappe()
        {
            var instance = new T();

            var properties = typeof(T).GetTypeInfo().DeclaredProperties;

            foreach (var property in properties)
            {
                var htmlParserAttr = property.GetCustomAttribute<BaseParserAttribute>();

                if (htmlParserAttr == null) continue;
                var xPath = htmlParserAttr.XPathExpression;

                var navigator = Document.CreateNavigator();
                if (navigator == null) continue;
                var xPathNode = navigator.Select(xPath);

                if (!xPathNode.MoveNext()) continue;
                var tagValue = xPathNode.Current.InnerXml;
                string stringValue;

                var pattern = htmlParserAttr.RegexPattern;
                if (!string.IsNullOrEmpty(pattern))
                {
                    var regex = new Regex(pattern);
                    var match = regex.Match(tagValue);

                    if (htmlParserAttr is BooleanParserAttribute)
                        stringValue = match.Success.ToString();
                    else
                        stringValue = match.Groups[1].Value;
                }
                else
                {
                    stringValue = tagValue;
                }

                object convertedType = null;
                if (!string.IsNullOrEmpty(stringValue))
                {
                    var propertyType = property.PropertyType;
                    propertyType = Nullable.GetUnderlyingType(propertyType) ?? propertyType;
                    convertedType = Convert.ChangeType(stringValue, propertyType);
                }

                property.SetValue(instance, convertedType);
            }

            return instance;
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