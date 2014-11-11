using HtmlAgilityPack;
using System.Linq;
using WTM.CorePCL.Application.Scrapper;
using WTM.CorePCL.Domain.WebsiteEntities.Base;
using System.Reflection;

namespace WTM.CorePCL.Application
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
            var uri = this.MakeUri();
            var stream = webClient.GetStream(uri);
            this.document = htmlParser.GetHtmlDocument(stream);
            return Scrappe();
        }

        protected abstract T Scrappe();

        private void Scrappe<T>()
        {
            var type = typeof(T);
            var properties = type.GetTypeInfo()
                                 .DeclaredProperties
                                 .Where(p => p.CustomAttributes.Any());

            //foreach (var property in properties)
            //{
            //    var htmlParserAttr = property as HtmlParserAttribute;
            //    if (htmlParserAttr != null)
            //    {
            //        var jQueryResult = htmlParserAttr.XPathExpression;
            //        // TODO 
            //    }

            //    var authenticatedAttr = property as AuthenticatedUser;
            //    var mandatoryAttr = property as MandatoryAttribute;
            //}
        }
    }
}