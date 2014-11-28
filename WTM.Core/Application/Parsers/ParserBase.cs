using System;
using System.Reflection;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using WTM.Core.Application.Attributes;
using WTM.Core.Domain.WebsiteEntities.Base;

namespace WTM.Core.Application.Parsers
{
    public abstract class ParserBase<T> : IPageIdentifier
        where T : IWebsiteEntityBase, new()
    {
        private readonly IWebClient webClient;
        private readonly IHtmlParser htmlParser;

        public abstract string Identifier { get; }

        protected ParserBase(IWebClient webClient, IHtmlParser htmlParser)
        {
            this.webClient = webClient;
            this.htmlParser = htmlParser;
        }

        public T Parse(string parameter)
        {
            var uri = MakeUri(parameter);
            HtmlDocument document;
            using (var stream = webClient.GetStream(uri))
            {
                document = htmlParser.GetHtmlDocument(stream);
            }

            var instance = new T();

            BeforeParse(instance, document);
            Parse(instance, document);
            AfterParse(instance, document);

            return instance;
        }

        protected virtual Uri MakeUri(string parameter)
        {
            return new Uri(webClient.UriBase, Identifier + "/" + parameter);
        }

        protected virtual void BeforeParse(T instance, HtmlDocument htmlDocument)
        { }

        protected virtual void Parse(T instance, HtmlDocument htmlDocument)
        {
            var properties = typeof(T).GetTypeInfo().DeclaredProperties;

            foreach (var property in properties)
            {
                var htmlParserAttr = property.GetCustomAttribute<BaseParserAttribute>();

                if (htmlParserAttr == null) continue;
                var xPath = htmlParserAttr.XPathExpression;

                var navigator = htmlDocument.CreateNavigator();
                if (navigator == null) continue;
                var xPathNode = navigator.Select(xPath);

                if (!xPathNode.MoveNext()) continue;
                var tagValue = xPathNode.Current.InnerXml.Trim();
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

        protected virtual void AfterParse(T instance, HtmlDocument htmlDocument)
        { }
    }
}