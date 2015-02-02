using System;
using System.Net;
using WTM.WebsiteClient.Domain;

namespace WTM.WebsiteClient.Application.Parsers
{
    internal abstract class SearchBaseParser<T> : ParserBase<SearchResultCollection> 
    {
        public override string Identifier { get { return "search"; } }

        protected abstract string SearchIdentifier { get; }

        protected SearchBaseParser(IWebClient webClient, IHtmlParser htmlParser)
            : base(webClient, htmlParser)
        { }

        public SearchResultCollection Search(string criteria)
        {
            var uri = MakeUri(criteria);
            return base.Parse(uri);
        }

        protected override Uri MakeUri(string parameter = null)
        {
            var encodedParameter = WebUtility.UrlEncode(parameter);
            return new Uri(WebClient.UriBase, string.Format("{0}?q={1}&t={2}", Identifier, encodedParameter, SearchIdentifier));
        }
    }
}