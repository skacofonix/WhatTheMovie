using System;

namespace WTM.Core.Application
{
    public interface IHtmlParser
    {
        HtmlAgilityPack.HtmlDocument GetHtmlDocument(System.IO.Stream stream);
    }
}
