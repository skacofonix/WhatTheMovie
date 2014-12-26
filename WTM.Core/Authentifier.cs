using System;
using System.IO;
using System.Linq;
using System.Net;
using HtmlAgilityPack;
using WTM.Core.Application;

namespace WTM.Core
{
    internal class Authentifier
    {
        public Cookie CookieSession { get; private set; }

        private readonly IWebClient webClient;
        private readonly IHtmlParser htmlParser;

        public Authentifier(IWebClient webClient, IHtmlParser htmlParser)
        {
            this.webClient = webClient;
            this.htmlParser = htmlParser;
        }

        public bool Login(string login, string password)
        {
            var loginSuccess = false;

            var uri = new Uri(webClient.UriBase, "user/login");

            var getRequestBuilder = new HttpRequestBuilder();
            getRequestBuilder.AddParameter("name", login);
            getRequestBuilder.AddParameter("upassword", password);
            var data = getRequestBuilder.ToString();

            var webResponse = webClient.Post(uri, data);

            HtmlDocument document;
            using (var stream = webResponse.GetResponseStream())
            {
                document = htmlParser.GetHtmlDocument(stream);
            }

            var nodeContainer = document.GetElementbyId("container");
            var nodeFlashMessageInfo = nodeContainer.ChildNodes.FirstOrDefault(n => n.Attributes.Any(attr => attr.Name == "class" && attr.Value == "flash_message flash_info"));

            if (nodeFlashMessageInfo != null && nodeContainer.InnerHtml.Contains("Welcome"))
            {
                loginSuccess = true;
                var httpWebResponse = webResponse as HttpWebResponse;
                if (httpWebResponse != null)
                {
                    for (var index = 0; index < httpWebResponse.Cookies.Count; index++)
                    {
                        var cookie = httpWebResponse.Cookies[index];
                        if (cookie.Name == "_wtm2_session")
                        {
                            CookieSession = cookie;
                            break;
                        }
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
