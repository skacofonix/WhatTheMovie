using HtmlAgilityPack;
using System.IO;

namespace WTM.CorePCL.Application
{
    public class HtmlParser : IHtmlParser
    {
        public HtmlDocument GetHtmlDocument(Stream stream)
        {
            var document = new HtmlDocument();
            document.Load(stream);
            return document;
        }
    }
}