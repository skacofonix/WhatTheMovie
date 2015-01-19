using System.Diagnostics;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml.XPath;
using WTM.Core.Application.Attributes;
using WTM.Core.Domain.WebsiteEntities;

namespace WTM.Core.Application.Parsers
{
    public abstract class ParserBase<T> : IPageIdentifier
        where T : IWebsiteEntityBase, new()
    {
        protected readonly IWebClient WebClient;
        protected readonly IHtmlParser HtmlParser;

        public abstract string Identifier { get; }

        protected ParserBase(IWebClient webClient, IHtmlParser htmlParser)
        {
            this.WebClient = webClient;
            this.HtmlParser = htmlParser;
        }

        protected virtual T Parse(string parameter = null)
        {
            var uri = MakeUri(parameter);
            HtmlDocument document;

            using (var stream = WebClient.GetStream(uri))
            {
                document = HtmlParser.GetHtmlDocument(stream);
            }

            var instance = new T();

            ParseHtmlDocument(instance, document);

            return instance;
        }

        protected virtual Uri MakeUri(string parameter)
        {
            var relativeUri = Identifier;
            if (!string.IsNullOrEmpty(parameter))
            {
                if (!parameter.StartsWith("/"))
                    relativeUri += "/";
                relativeUri += parameter;
            }

            return new Uri(WebClient.UriBase, relativeUri);
        }

        protected virtual void ParseHtmlDocument(T instance, HtmlDocument htmlDocument)
        {
            var navigator = htmlDocument.CreateNavigator();
            if (navigator == null)
                throw new ArgumentException("Impossible to create navigator over HtmlDocument");

            ParseObject(instance, navigator);
        }

        private readonly Type[] simpleTypes = {typeof(int), typeof(bool), typeof(string), typeof(DateTime)};

        private void ParseObject(object instance, XPathNavigator navigator)
        {
            var properties = GetPropertiesWithParserAttribute(instance);

            foreach (var property in properties)
            {
                ParseProperty(instance, property, navigator);
            }
        }

        private void ParseProperty(object instance, PropertyInfo property, XPathNavigator navigator)
        {
            var parseAttr = GetParserAttribute(property);
            var nodeIterator = GetXPathIterator(navigator, parseAttr.XPathExpression);

            if (IsSimpleType(property))
            {
                // Simple type
                ParseSimpleType(instance, property, parseAttr, nodeIterator);
            }
            else if (IsArrayType(property))
            {
                // List type
                ParseArrayType(instance, property, nodeIterator);
            }
            else if (IsCustomType(property))
            {
                // Custom type (WTM)
                var value = property.GetValue(instance);
                ParseObject(value, navigator);
            }
            else
            {
                // Unsuported type
            }
        }

        private XPathNodeIterator GetXPathIterator(XPathNavigator navigator, string xPathExpression)
        {
            return navigator.Select(xPathExpression);
        }

        private void ParseSimpleType(object instance, PropertyInfo property, BaseParserAttribute parseAttr, XPathNodeIterator nodeIterator)
        {
            var rawData = GetNextValue(nodeIterator);
            var stringValue = ExtractValueWithPattern(rawData, parseAttr);
            var typedValue = ConvertToPropertyType(instance, property, stringValue);
            SetPropertyValue(instance, property, typedValue);
        }

        private void ParseArrayType(object instance, PropertyInfo property, XPathNodeIterator nodeIterator)
        {
            var itemType = property.PropertyType.GenericTypeArguments.FirstOrDefault();
            if (itemType == null) return;

            var value = GetNextValue(nodeIterator);
            while (value != null)
            {
                value = GetNextValue(nodeIterator);
            }
        }

        private bool IsSimpleType(PropertyInfo propertyInfo)
        {
            var type = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;
            return simpleTypes.Contains(type);
        }

        private bool IsArrayType(PropertyInfo propertyInfo)
        {
            var type = propertyInfo.PropertyType;
            return type.GetInterfaces().Any(interfaceType => interfaceType.IsGenericType && interfaceType.GetGenericTypeDefinition() == typeof(IEnumerable<>));
        }

        private bool IsCustomType(PropertyInfo propertyInfo)
        {
            return propertyInfo.PropertyType.IsInstanceOfType(typeof (IWebsiteEntityBase));
        }

        private BaseParserAttribute GetParserAttribute(PropertyInfo property)
        {
            var htmlParserAttr = property.GetCustomAttribute<BaseParserAttribute>();
            return htmlParserAttr;
        }

        private string GetNextValue(XPathNodeIterator nodeIterator)
        {
            if (!nodeIterator.MoveNext())
                return null;

            return nodeIterator.Current.InnerXml.Trim();
        }

        private string ExtractValueWithPattern(string value, BaseParserAttribute attr)
        {
            var pattern = attr.RegexPattern;

            if (string.IsNullOrEmpty(value)) return value;
            if (string.IsNullOrEmpty(pattern)) return value;

            var regex = new Regex(pattern);
            var match = regex.Match(value);

            if (attr is BooleanParserAttribute)
                return match.Success.ToString();
            return match.Groups[1].Value;
        }

        private object ConvertToPropertyType(object instance, PropertyInfo property, string value)
        {
            object convertedType = null;
            if (!string.IsNullOrEmpty(value))
            {
                var propertyType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                convertedType = Convert.ChangeType(value, propertyType);
            }
            return convertedType;
        }

        private void SetPropertyValue(object instance, PropertyInfo property, object value)
        {
            property.SetValue(instance, value);
        }

        private static IEnumerable<PropertyInfo> GetPropertiesWithParserAttribute<U>(U instance) 
        {
            var properties = instance.GetType()
                .GetTypeInfo()
                .DeclaredProperties
                .Where(t => t.GetCustomAttributes(typeof(BaseParserAttribute)).Any());
            //var properties =  instance.GetType().GetTypeInfo().DeclaredProperties;
            return properties;
        }
    }
}