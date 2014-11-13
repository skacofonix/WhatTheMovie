using System.IO;
using HtmlAgilityPack;

namespace WTM.Core.Application
{
    public interface IHtmlParser
    {
        HtmlDocument GetHtmlDocument(Stream stream);
    }
}
