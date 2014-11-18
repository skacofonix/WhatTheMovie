using HtmlAgilityPack;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using WTM.Core.Application.Attributes;
using WTM.Core.Application.Scrapper;
using WTM.Core.Domain.WebsiteEntities.Base;

namespace WTM.Core.Application
{
    public abstract class ScrapperT<T> : BaseScrapper
        where T : IWebsiteEntityBase
    {
        private IWebClient webClient;
        private IHtmlParser htmlParser;
        protected HtmlDocument document;

        public ScrapperT(IWebClient webClient, IHtmlParser htmlParser)
        {
            this.webClient = webClient;
            this.htmlParser = htmlParser;
        }

        protected override string Parameter
        {
            get { return parameter; }
        }
        private string parameter;

        public T Scrappe(T instance, string parameter = null)
        {
            this.parameter = parameter;
            var uri = MakeUri();
            var stream = webClient.GetStream(uri);
            document = htmlParser.GetHtmlDocument(stream);
            return Scrappe(instance);
        }

        protected virtual T Scrappe(T instance)
        {
            var properties = typeof(T).GetTypeInfo().DeclaredProperties;

            foreach (var property in properties)
            {
                var propertyType = property.PropertyType;

                var htmlParserAttr = property.GetCustomAttribute<HtmlParserAttribute>();

                if (htmlParserAttr != null)
                {
                    var xPath = htmlParserAttr.XPathExpression;
                    
                    var navigator = document.CreateNavigator();
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
                                stringValue = match.Groups[1].Value;
                            }
                            else
                            {
                                stringValue = tagValue;
                            }

                            // TODO converssion here ?

                            property.SetValue(instance, stringValue);
                        }
                    }
                }

                var authenticatedAttr = property.GetCustomAttribute<AuthenticatedUser>();
                var mandatoryAttr = property.GetCustomAttribute<MandatoryAttribute>();
            }
            return default(T);
        }
    }
}