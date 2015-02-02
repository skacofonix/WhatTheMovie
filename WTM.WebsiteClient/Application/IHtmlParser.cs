using System.IO;
using HtmlAgilityPack;

namespace WTM.WebsiteClient.Application
{
    public interface IHtmlParser
    {
        HtmlDocument GetHtmlDocument(Stream s);
        HtmlDocument GetHtmlDocument(string s);
    }
}
