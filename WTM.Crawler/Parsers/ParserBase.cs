using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using HtmlAgilityPack;
using WTM.Crawler.Domain;

namespace WTM.Crawler.Parsers
{
    public abstract class ParserBase<T>
        where T : IWebsiteEntity, new()
    {
        protected readonly IWebClient WebClient;
        protected readonly IHtmlParser HtmlParser;
        private readonly CookieFactory cookieFactory;

        protected abstract string Identifier { get; }

        protected ParserBase(IWebClient webClient, IHtmlParser htmlParser)
        {
            WebClient = webClient;
            HtmlParser = htmlParser;
            cookieFactory = new CookieFactory(webClient);
        }

        protected virtual T Parse(string parameter = null)
        {
            var uri = MakeUri(parameter);
            return Parse(uri);
        }

        protected virtual void SetUserToken(string userToken)
        {
            if (userToken != null)
            {
                var cookie = cookieFactory.Create(userToken);
                WebClient.SetCookie(cookie);
            }
        }

        protected virtual Uri MakeUri(string criteria = null)
        {
            var relativeUri = Identifier;
            if (!string.IsNullOrEmpty(criteria))
            {
                if (!criteria.StartsWith("/"))
                    relativeUri += "/";
                relativeUri += criteria;
            }

            return new Uri(WebClient.UriBase, relativeUri);
        }
        
        protected T Parse(Uri uri)
        {
            var stopwatch = Stopwatch.StartNew();

            HtmlDocument document;
            try
            {
                using (var stream = WebClient.GetStream(uri))
                {
                    document = HtmlParser.GetHtmlDocument(stream);
                }
            }
            catch (Exception ex)
            {
                throw new CrawlerException("Error occured when parsing HTML page " + uri, ex);
            }

            var instance = new T {ParseInfos = new List<ParseInfo>()};

            try
            {
                ParseHtmlDocument(instance, document);
            }
            catch (Exception ex)
            {
                throw new CrawlerException("Error occured when parsing entity " + instance.GetType(), ex);
            }

            stopwatch.Stop();
            instance.ParseDuration = new TimeSpan(stopwatch.ElapsedTicks);
            instance.ParseDateTime = DateTime.Now;

            return instance;
        }

        protected abstract void ParseHtmlDocument(T instance, HtmlDocument htmlDocument);
    }
}