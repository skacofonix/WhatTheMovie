using System.IO;
using HtmlAgilityPack;

namespace WTM.Crawler
{
    public interface IHtmlParser
    {
        HtmlDocument GetHtmlDocument(Stream s);

        HtmlDocument GetHtmlDocument(string s);
    }
}