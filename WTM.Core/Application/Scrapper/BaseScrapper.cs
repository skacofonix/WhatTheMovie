using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WTM.Core.Application.Scrapper
{
    public abstract class BaseScrapper
    {
        protected const string urlRoot = "http://www.whatthemovie.com";
        protected HtmlDocument document;

        protected T TryParseElement<T>(Func<T> func)
            where T : class
        {
            T value = null;

            try
            {
                value = func();
            }
            catch (Exception ex)
            {
                // Log
                value = null;
            }

            return value;
        }

        protected void ReceiveHtmlDocument()
        {
            var uri = MakeUri();
            var webRequest = GetWebRequest(uri);
            var webResponse = GetWebResponse(webRequest);
            this.document = LoadHtmlDocument(webResponse);
        }

        protected void LoadHtmlDocument(Stream stream)
        {
            var doc = new HtmlDocument();
            doc.Load(stream);
            document = doc;
        }

        protected abstract Uri MakeUri();

        private HttpWebRequest GetWebRequest(Uri uri)
        {
            return WebRequest.CreateHttp(uri);
        }

        private WebResponse GetWebResponse(HttpWebRequest webRequest)
        {
            var asyncResult = webRequest.BeginGetResponse(new AsyncCallback(state =>
            {
            }), null);
            return webRequest.EndGetResponse(asyncResult);
        }

        private HtmlDocument LoadHtmlDocument(WebResponse webResponse)
        {
            var document = new HtmlDocument();
            using (var stream = webResponse.GetResponseStream())
            {
                document.Load(stream);
            }
            return document;
        }

        protected abstract void DoWorkInternal();
    }
}
