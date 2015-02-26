using System;
using System.Collections.Generic;
using System.Diagnostics;
using HtmlAgilityPack;
using WTM.Domain;
using WTM.Domain.Interfaces;

namespace WTM.WebsiteClient.Parsers
{
    public abstract class ParserBase<T>
        where T : IWebsiteEntity, new()
    {
        protected readonly IWebClient WebClient;
        protected readonly IHtmlParser HtmlParser;

        public abstract string Identifier { get; }

        protected ParserBase(IWebClient webClient, IHtmlParser htmlParser)
        {
            WebClient = webClient;
            HtmlParser = htmlParser;
        }

        protected virtual T Parse(string parameter = null)
        {
            var uri = MakeUri(parameter);
            return Parse(uri);
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
            using (var stream = WebClient.GetStream(uri))
            {
                document = HtmlParser.GetHtmlDocument(stream);
            }

            var instance = new T();

            instance.ParseInfos = new List<ParseInfo>();

            try
            {
                ParseHtmlDocument(instance, document);
            }
            catch (Exception ex)
            {
                instance.ParseInfos.Add(new ParseInfo(ParseLevel.Fatal, "Fatal error occur when parse entity", ex));
            }

            stopwatch.Stop();
            instance.ParseDuration = new TimeSpan(stopwatch.ElapsedTicks);
            instance.ParseDateTime = DateTime.Now;

            return instance;
        }

        protected abstract void ParseHtmlDocument(T instance, HtmlDocument htmlDocument);
    }
}