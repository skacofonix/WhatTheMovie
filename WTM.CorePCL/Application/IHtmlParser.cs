namespace WTM.CorePCL.Application
{
    public interface IHtmlParser
    {
        HtmlAgilityPack.HtmlDocument GetHtmlDocument(System.IO.Stream stream);
    }
}
