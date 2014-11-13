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

        public T Scrappe(string parameter = null)
        {
            this.parameter = parameter;
            var uri = MakeUri();
            var stream = webClient.GetStream(uri);
            document = htmlParser.GetHtmlDocument(stream);
            return Scrappe();
        }

        protected virtual T Scrappe()
        {
            var properties = typeof(T).GetTypeInfo().DeclaredProperties;

            foreach (var property in properties)
            {
                string stringValue = null;
                var htmlParserAttr = property.GetCustomAttribute<HtmlParserAttribute>();

                if (htmlParserAttr != null)
                {
                    var xPath = htmlParserAttr.XPathExpression;
                    
                    var navigator = document.CreateNavigator();
                    var xPathNode = navigator.Select(xPath);
                    
                    if (xPathNode.MoveNext())
                    {
                        var tagValue = xPathNode.Current.InnerXml;

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
                    }
                }

                var authenticatedAttr = property.GetCustomAttribute<AuthenticatedUser>();
                var mandatoryAttr = property.GetCustomAttribute<MandatoryAttribute>();
            }
            return default(T);
        }
    }
}