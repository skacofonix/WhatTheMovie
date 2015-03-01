using System.Net;
using System.Text.RegularExpressions;
using WTM.Domain;
using WTM.Domain.Interfaces;

namespace WTM.Crawler.Services
{
    public class OverviewDisplayOptionsService : IReadWriteService<IOverviewDisplayOptions>
    {
        private readonly IWebClient webClient;

        private const string OverviewDisplayOptionsCookieName = "OverviewDisplayOptions";
        private const string OverviewOptionsCookieBodyFormat = "{\"solved\":\"{0}\"@@@\"unsolved\":\"{1}\"@@@\"posted\":\"{2}\"}";
        private readonly Regex overviewOptionsCookieBodyRegex = new Regex("{\"solved\":\"(.*)\"@@@\"unsolved\":\"(.*)\"@@@\"posted\":\"(.*)\"}");
        private const string Show = "show";
        private const string Hide = "dontshow";

        public OverviewDisplayOptionsService(IWebClient webClient)
        {
            this.webClient = webClient;
        }

        public IOverviewDisplayOptions Read()
        {
            var cookie = webClient.GetCookie(OverviewDisplayOptionsCookieName);
            if (cookie == null) return null;

            var match = overviewOptionsCookieBodyRegex.Match(cookie.Value);
            if (!match.Success) return null;

            IOverviewDisplayOptions overviewDisplayOptions = new OverviewDisplayOptions();
            overviewDisplayOptions.ShowSolved = match.Groups[1].Value == Show;
            overviewDisplayOptions.ShowUnsolved = match.Groups[2].Value == Show;
            overviewDisplayOptions.ShowPosted = match.Groups[3].Value == Show;

            return overviewDisplayOptions;
        }

        public bool Write(IOverviewDisplayOptions instance)
        {
            var cookieBody = string.Format(OverviewOptionsCookieBodyFormat,
                instance.ShowSolved ? Show : Hide,
                instance.ShowUnsolved ? Show : Hide,
                instance.ShowPosted ? Show : Hide);

            var cookie = new Cookie(OverviewDisplayOptionsCookieName, cookieBody);

            webClient.SetCookie(cookie);

            return true;
        }
    }
}
