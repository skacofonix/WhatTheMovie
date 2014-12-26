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

        public void SetCookie(Cookie cookie)
        {
            cookies.Add(cookie);
        }

        public void RemoveCookie(Cookie cookie)
        {
            cookies.Remove(cookie);
        }

        public Stream GetStream(Uri uri)
        {
            var webResponse = GetWebResponse(uri);
            var stream = webResponse.GetResponseStream();
            return stream;
        }

        public WebResponse Post(Uri source, Uri destination, string data)
        {
            var request = CreateHttpWebRequest(destination);

            request.Referer = source.AbsoluteUri;

            if (data != null)
            {
                request.ContentLength = data.Length;
                var sw = new StreamWriter(request.GetRequestStream());
                sw.Write(data);
                sw.Close();
            }

            return request.GetResponse();
        }

        public WebResponse Post(Uri uri, string data = null)
        {
            var request = CreateHttpWebRequest(uri);

            if (data != null)
            {
                request.ContentLength = data.Length;
                var sw = new StreamWriter(request.GetRequestStream());
                sw.Write(data);
                sw.Close();
            }

            return request.GetResponse();
        }

        public void DownloadFile(Uri uri, string destinationFile)
        {
            var webClient = new System.Net.WebClient();
            webClient.DownloadFile(uri, destinationFile);
        }

        private WebResponse GetWebResponse(Uri uri)
        {
            var webRequest = CreateHttpWebRequest(uri);
            return GetWebResponse(webRequest);
        }

        private WebResponse GetWebResponse(HttpWebRequest webRequest)
        {
            var task = webRequest.GetResponseAsync();
            task.Wait();
            return task.Result;
        }

        private HttpWebRequest CreateHttpWebRequest(Uri uri)
        {
            var httpWebRequest = WebRequest.CreateHttp(uri);

            SetupWebRequest(httpWebRequest);
            SetupHttpWebRequest(httpWebRequest, uri);

            return httpWebRequest;
        }

        private void SetupWebRequest(WebRequest webRequest)
        {
            webRequest.Proxy = new WebProxy("localhost:8888");
        }

        private void SetupHttpWebRequest(HttpWebRequest httpWebRequest, Uri uri)
        {
            httpWebRequest.CookieContainer = new CookieContainer();
            if (cookies != null && cookies.Any())
            {
                foreach (var cookie in cookies)
                    httpWebRequest.CookieContainer.Add(cookie);
            }

            httpWebRequest.KeepAlive = true;
            httpWebRequest.Host = uri.Host;
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
        }
    }
}