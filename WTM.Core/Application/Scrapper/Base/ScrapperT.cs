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
        private readonly IWebClient webClient;
        private readonly IHtmlParser htmlParser;
        protected HtmlDocument Document;

        protected abstract string Identifier { get; }
        private string parameter;

        protected ScrapperT(IWebClient webClient, IHtmlParser htmlParser)
        {
            this.webClient = webClient;
            this.htmlParser = htmlParser;
        }

        public T Scrappe(string parameter = null)
        {
            this.parameter = parameter;
            var uri = MakeUri();
            using (var stream = webClient.GetStream(uri))
            {
                Document = htmlParser.GetHtmlDocument(stream);
            }
            return Scrappe();
        }

        protected virtual Uri MakeUri()
        {
            return new Uri(webClient.UriBase, Identifier + "/" + parameter);
        }

        protected virtual T Scrappe()
        {
            var instance = new T();

            var properties = typeof(T).GetTypeInfo().DeclaredProperties;

            foreach (var property in properties)
            {
                var htmlParserAttr = property.GetCustomAttribute<BaseParserAttribute>();

                if (htmlParserAttr != null)
                {
                    var xPath = htmlParserAttr.XPathExpression;

                    var navigator = Document.CreateNavigator();
                    if (navigator != null)
                    {
                        var xPathNode = navigator.Select(xPath);

                        if (xPathNode.MoveNext())
                        {
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
                    }
                }
            }

            return instance;
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