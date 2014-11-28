using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace WTM.Core.Application
{
    internal abstract class WebClient : IWebClient
    {
        public Uri UriBase { get; private set; }

        protected WebClient(Uri uriBase)
        {
            UriBase = uriBase;
        }

        private readonly IList<Cookie> cookies = new List<Cookie>();

        internal void SetCookie(Cookie cookie)
        {
            cookies.Add(cookie);
        }

        internal void RemoveCookie(Cookie cookie)
        {
            cookies.Remove(cookie);
        }

        public Stream GetStream(Uri uri)
        {
            var webResponse = GetWebResponse(uri);
            var stream = GetStream(webResponse);
            return stream;
        }

        public WebResponse Post(Uri uri, string data = null)
        {
            var request = (HttpWebRequest)WebRequest.Create(uri);
            request.CookieContainer = new CookieContainer();
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";

            if (data != null)
            {
                request.ContentLength = data.Length;
                var sw = new StreamWriter(request.GetRequestStream());
                sw.Write(data);
                sw.Close();
            }

            return request.GetResponse();
        }

        private WebResponse GetWebResponse(Uri uri)
        {
            var webRequest = GetWebRequest(uri);

            if (cookies != null && cookies.Any())
            {
                webRequest.CookieContainer = new CookieContainer();
                foreach (var cookie in cookies)
                    webRequest.CookieContainer.Add(cookie);
            }

            var webResponse = GetWebResponse(webRequest);
            return webResponse;
        }

        private HttpWebRequest GetWebRequest(Uri uri)
        {
            return WebRequest.CreateHttp(uri);
        }

        private WebResponse GetWebResponse(HttpWebRequest webRequest)
        {
            var task = webRequest.GetResponseAsync();

            task.Wait();

            return task.Result;
        }

        private Stream GetStream(WebResponse webResponse)
        {
            var stream = webResponse.GetResponseStream();
            return stream;
        }
    }
}