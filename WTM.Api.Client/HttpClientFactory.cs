using System;
using System.Net;
using System.Net.Http;

namespace WTM.Api.Client
{
    public class HttpClientFactory
    {
        private readonly ISettings settings;

        public HttpClientFactory(ISettings settings)
        {
            this.settings = settings;
        }

        public HttpClient CreateHttpClient()
        {
            var handler = new HttpClientHandler
            {
                //CookieContainer = cookies,
                //UseCookies = true,
               //UseDefaultCredentials = false,
               //Proxy = new HttpP
               //UseProxy = true,
            };

            var httpClient = new HttpClient();


            return httpClient;
        }
    }

    public class WebProxy : IWebProxy
    {
        private Uri proxy;
        private ICredentials credentials;

        public WebProxy(ISettings settings)
        {
            proxy = settings.Proxy;
            credentials = settings.ProxyCredentials;
        }

        public Uri GetProxy(Uri destination)
        {
            throw new NotImplementedException();
        }

        public bool IsBypassed(Uri host)
        {
            throw new NotImplementedException();
        }

        public ICredentials Credentials { get; set; }
    }
}
