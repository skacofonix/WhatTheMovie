using System.IO;
using HtmlAgilityPack;

namespace WTM.CorePCL.Application
{
    public interface IHtmlParser
    {
        HtmlDocument GetHtmlDocument(Stream stream);
    }
}
