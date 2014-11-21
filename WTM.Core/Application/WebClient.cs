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

        public WebResponse Post(Uri uri, string data)
        {
            var request = (HttpWebRequest)WebRequest.Create(uri);
            request.CookieContainer = new CookieContainer();
            request.Method = "POST";
            //request.Host = "whatthemovie.com";
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            //request.Referer = Properties.Resources.URLroot;
            request.ContentLength = data.Length;

            var sw = new StreamWriter(request.GetRequestStream());
            sw.Write(data);
            sw.Close();

            return request.GetResponse();
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