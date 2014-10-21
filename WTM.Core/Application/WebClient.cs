using System;
using System.IO;
using System.Net;

namespace WTM.Core.Application
{
    internal class WebClient : IWebClient
    {
        public Stream GetStream(Uri uri)
        {
            var webResponse = GetWebResponse(uri);
            var stream = GetStream(webResponse);
            return stream;
        }

        private WebResponse GetWebResponse(Uri uri)
        {
            var webRequest = GetWebRequest(uri);
            var webResponse = GetWebResponse(webRequest);
            return webResponse;
        }

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

        private Stream GetStream(WebResponse webResponse)
        {
            var stream = webResponse.GetResponseStream();
            return stream;
        }
    }
}