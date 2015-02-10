﻿using HtmlAgilityPack;
using System;
using System.Diagnostics;
using WTM.Domain.Interfaces;

namespace WTM.WebsiteClient.Application.Parsers
{
    public abstract class ParserBase<T> : IPageIdentifier
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

        protected virtual Uri MakeUri(string parameter = null)
        {
            var relativeUri = Identifier;
            if (!string.IsNullOrEmpty(parameter))
            {
                if (!parameter.StartsWith("/"))
                    relativeUri += "/";
                relativeUri += parameter;
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

            try
            {
                ParseHtmlDocument(instance, document);
            }
            catch (Exception ex)
            {
                // TODO : Log
            }

            stopwatch.Stop();
            instance.ParseDuration = new TimeSpan(stopwatch.ElapsedTicks);
            instance.ParseDateTime = DateTime.Now;

            return instance;
        }

        protected abstract void ParseHtmlDocument(T instance, HtmlDocument htmlDocument);
    }
}