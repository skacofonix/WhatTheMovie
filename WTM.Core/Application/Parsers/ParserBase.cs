using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        protected virtual T Parse(string parameter)
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
            var navigator = htmlDocument.CreateNavigator();
            if (navigator == null)
                throw new ArgumentException("Impossible to create navigator over HtmlDocument");

            var properties = GetPropertiesWithParserAttribute(instance);

            foreach (var property in properties)
            {
                var propertyType = property.PropertyType;
                var htmlParserAttr = property.GetCustomAttribute<BaseParserAttribute>();
                var xPath = htmlParserAttr.XPathExpression;

                var xPathNode = navigator.Select(xPath);

                if (IsEnumerableProperty(propertyType))
                {
                    var typeOfList = propertyType.GetGenericArguments().FirstOrDefault();
                    if (typeOfList != null)
                    {
                        // TODO : Check if type of list using ParserAttribute
                        // Useless, beacause this control was run into reflection call
                    }

                    while (xPathNode.MoveNext())
                    {
                        var blop = xPathNode.Current.InnerXml.Trim();

                        // TODO : Work in progress
                    }
                }
                else
                {
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
                        propertyType = Nullable.GetUnderlyingType(propertyType) ?? propertyType;
                        convertedType = Convert.ChangeType(stringValue, propertyType);
                    }

                    property.SetValue(instance, convertedType);
                }
            }
        }

        private static bool IsEnumerableProperty(Type propertyType)
        {
            return propertyType.GetInterfaces().Any(interfaceType => interfaceType.IsGenericType && interfaceType.GetGenericTypeDefinition() == typeof(IEnumerable<>));
        }

        private static IEnumerable<PropertyInfo> GetPropertiesWithParserAttribute<U>(U instance) where U : IWebsiteEntityBase
        {
            var properties = typeof(U).GetTypeInfo()
                .DeclaredProperties
                .Where(t => t.GetCustomAttributes(typeof(BaseParserAttribute)).Any());
            return properties;
        }

        protected virtual void AfterParse(T instance, HtmlDocument htmlDocument)
        { }
    }
}