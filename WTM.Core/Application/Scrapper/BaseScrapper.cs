using HtmlAgilityPack;
using System;
using System.Collections.Generic;
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

        protected void ReceiveHtmlDocument()
        {
            var uri = MakeUri();
            var webRequest = GetWebRequest(uri);
            var webResponse = GetWebResponse(webRequest);
            this.document = LoadHtmlDocument(webResponse);
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
