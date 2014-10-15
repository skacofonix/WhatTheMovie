using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTM.Core.Application.Scrapper;
using WTM.Core.Domain.WebsiteEntities.Base;
using System.Reflection;
using WTM.Core.Application.Attributes;

namespace WTM.Core.Application
{
    public abstract class ScrapperT<T> : BaseScrapper
        where T : WebsiteEntityBase
    {
        private WebClient webClient = new WebClient();
        private HtmlParser parser = new HtmlParser();
        protected HtmlDocument document;

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
            this.document = parser.GetHtmlDocument(stream);
            return Scrappe();
        }

        public T Scrappe(Stream stream)
        {
            this.document = parser.GetHtmlDocument(stream);
            return Scrappe();
        }

        protected abstract T Scrappe();

        protected void Blop<T>()
        {
            var type = typeof(T);
            var properties = type.GetTypeInfo().DeclaredProperties
                                            .Where(p => p.CustomAttributes.Any(ca => ca.AttributeType == typeof(HtmlParserAttribute)));

            var htmlParserProperty = properties as HtmlParserAttribute;
        }
    }
}