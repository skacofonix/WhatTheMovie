using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace WTM.WebsiteClient
{
    public abstract class WebClient : IWebClient
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

        public Cookie GetCookie(string name)
        {
            return cookies.FirstOrDefault(w => w.Name == name);
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

        public WebResponse Get(Uri uri)
        {
            return GetWebResponse(uri);
        }

        public WebResponse Post(Uri source, Uri destination, string data)
        {
            var request = CreateHttpPostWebRequest(destination);

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
            var request = CreateHttpPostWebRequest(uri);

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
            var webRequest = CreateHttpGetWebRequest(uri);
            return GetWebResponse(webRequest);
        }

        private WebResponse GetWebResponse(HttpWebRequest webRequest)
        {
            var task = webRequest.GetResponseAsync();
            task.Wait();
            return task.Result;
        }

        private HttpWebRequest CreateHttpGetWebRequest(Uri uri)
        {
            var httpWebRequest = WebRequest.CreateHttp(uri);

            SetupWebRequest(httpWebRequest);
            SetupHttpRequest(httpWebRequest, uri);

            return httpWebRequest;
        }

        private HttpWebRequest CreateHttpPostWebRequest(Uri uri)
        {
            var httpWebRequest = WebRequest.CreateHttp(uri);

            SetupWebRequest(httpWebRequest);
            SetupHttpRequest(httpWebRequest, uri);
            SetupHttpPostRequest(httpWebRequest);

            return httpWebRequest;
        }

        private void SetupWebRequest(WebRequest webRequest)
        {
            webRequest.Proxy = new WebProxy("localhost:8888");
        }

        private void SetupHttpRequest(HttpWebRequest httpWebRequest, Uri uri)
        {
            httpWebRequest.CookieContainer = new CookieContainer();
            if (cookies != null && cookies.Any())
            {
                foreach (var cookie in cookies)
                    httpWebRequest.CookieContainer.Add(cookie);
            }

            httpWebRequest.KeepAlive = true;
            httpWebRequest.Host = uri.Host;
            httpWebRequest.Headers.Add("Origin", UriBase.ToString());
            httpWebRequest.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
        }

        private void SetupHttpPostRequest(HttpWebRequest httpWebRequest)
        {
            httpWebRequest.Method = "POST";

            // X-Requested-With: XMLHttpRequest
            httpWebRequest.Headers.Add("X-Requested-With", "XMLHttpRequest");
        }
    }
}