using System;
using System.Net;
using WTM.Core.Application;

namespace WTM.Core
{
    internal class Authentifier
    {
        public Cookie CookieSession { get; private set; }

        private readonly IWebClient webClient;

        public Authentifier(IWebClient webClient)
        {
            this.webClient = webClient;
        }

        public bool Login(string login, string password)
        {
            var loginSuccess = false;

            var uri = new Uri(webClient.UriBase, "user/login");

            var getRequestBuilder = new GetRequestBuilder();
            getRequestBuilder.AddParameter("name", login);
            getRequestBuilder.AddParameter("upassword", password);
            var data = getRequestBuilder.ToString();

            var webResponse = webClient.Post(uri, data);

            var httpWebResponse = webResponse as HttpWebResponse;
            if (httpWebResponse != null)
            {
                for (var index = 0; index < httpWebResponse.Cookies.Count; index++)
                {
                    var cookie = httpWebResponse.Cookies[index];

                    loginSuccess = cookie.Name == "_wtm2_session";
                    if (loginSuccess)
                    {
                        CookieSession = cookie;
                        break;
                    }
                }
            }

            return loginSuccess;
        }

        public void Logout()
        {
            CookieSession = null;
        }
    }
}
