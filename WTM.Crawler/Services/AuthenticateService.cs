using System.Text.RegularExpressions;
using HtmlAgilityPack;
using System;
using System.Linq;
using System.Net;
using WTM.Crawler.Helpers;

namespace WTM.Crawler.Services
{
    public class AuthenticateService
    {
        public Cookie CookieSession { get; private set; }

        private readonly IWebClient webClient;
        private readonly IHtmlParser htmlParser;

        public AuthenticateService(IWebClient webClient, IHtmlParser htmlParser)
        {
            this.webClient = webClient;
            this.htmlParser = htmlParser;
        }

        public string Login(string username, string password)
        {
            string token = null;

            var uri = new Uri(webClient.UriBase, "user/login");

            var getRequestBuilder = new HttpRequestBuilder();
            getRequestBuilder.AddParameter("name", username);
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
            if (nodeFlashMessageInfo == null || !nodeContainer.InnerHtml.Contains("Welcome")) return null;

            // Check username
            var usernameNode = document.DocumentNode.SelectSingleNode("//li[@class='secondary_nav'][2]/a");
            if (usernameNode == null) return null;
            var usernameMatch = Regex.Match(usernameNode.GetAttributeValue("href", null), "/user/(.*)$");
            if (!usernameMatch.Success) return null;
            if (usernameMatch.Groups[1].Value != username) return null;

            var httpWebResponse = webResponse as HttpWebResponse;
            if (httpWebResponse == null) return null;
            for (var index = 0; index < httpWebResponse.Cookies.Count; index++)
            {
                var cookie = httpWebResponse.Cookies[index];
                if (cookie.Name != "_wtm2_session") continue;

                CookieSession = cookie;
                webClient.SetCookie(cookie);

                token = cookie.Value;

                break;
            }

            return token;
        }

        public void Logout()
        {
            webClient.RemoveCookie(CookieSession);
            CookieSession = null;
        }
    }
}