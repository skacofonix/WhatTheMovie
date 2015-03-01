using System.IO;
using HtmlAgilityPack;

namespace WTM.Crawler
{
    public class HtmlParser : IHtmlParser
    {
        public HtmlDocument GetHtmlDocument(Stream s)
        {
            var document = new HtmlDocument();
            document.Load(s);
            return document;
        }

        public HtmlDocument GetHtmlDocument(string s)
        {
            var document = new HtmlDocument();
            document.LoadHtml(s);
            return document;
        }
    }
}