using System;
using System.Net;

namespace WTM.Crawler
{
    internal class CookieFactory
    {
        private readonly string domain;

        public CookieFactory(IWebClient webClient)
        {
            domain = webClient.UriBase.Host;
        }

        public Cookie Create(string token)
        {
            return new Cookie
            {
                Name = "_wtm2_session",
                Value = token,
                Domain = domain,
                Path = "/",
                HttpOnly = true,
                Expires = DateTime.Now.AddYears(2)
            };
        }
    }
}