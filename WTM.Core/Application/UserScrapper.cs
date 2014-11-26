using WTM.Core.Application.Scrapper.Base;
using WTM.Core.Domain.WebsiteEntities;

namespace WTM.Core.Application
{
    internal class UserScrapper : ScrapperT<User>
    {
        protected override string Identifier { get { return "user"; } }

        public UserScrapper(IWebClient webClient, IHtmlParser htmlParser)
            : base(webClient, htmlParser)
        { }
    }
}
