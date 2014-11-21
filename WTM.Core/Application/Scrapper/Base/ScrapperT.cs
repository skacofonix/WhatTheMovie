using HtmlAgilityPack;
using System;
using System.Reflection;
using System.Text.RegularExpressions;
using WTM.Core.Application.Attributes;
using WTM.Core.Domain.WebsiteEntities.Base;

namespace WTM.Core.Application.Scrapper.Base
{
    public abstract class ScrapperT<T> : BaseScrapper
        where T : IWebsiteEntityBase
    {
        private readonly IWebClient webClient;
        private readonly IHtmlParser htmlParser;
        protected HtmlDocument Document;

        protected ScrapperT(IWebClient webClient, IHtmlParser htmlParser)
        {
            this.webClient = webClient;
            this.htmlParser = htmlParser;
        }

        protected override string Parameter
        {
            get { return parameter; }
        }
        private string parameter;

        public void Scrappe(T instance, string parameter = null)
        {
            this.parameter = parameter;
            var uri = MakeUri();
            var stream = webClient.GetStream(uri);
            Document = htmlParser.GetHtmlDocument(stream);
            Scrappe(instance);
        }

        protected virtual void Scrappe(T instance)
        {
            var properties = instance.GetType().GetTypeInfo().DeclaredProperties;

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
        }
    }
}