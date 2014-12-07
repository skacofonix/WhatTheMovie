using HtmlAgilityPack;
using System.IO;

namespace WTM.Core.Application
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