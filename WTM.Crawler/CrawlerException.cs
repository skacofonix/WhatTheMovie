using System;

namespace WTM.Crawler
{
    public class CrawlerException : Exception
    {
        public CrawlerException()
        { }

        public CrawlerException(string message)
            : base(message)
        { }

        public CrawlerException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}