using WTM.Core.Application.Scrapper.Base;
using WTM.Core.Domain.WebsiteEntities;

namespace WTM.Core.Application
{
    public class UserScrapper : ScrapperT<IUser>
    {
        protected override string Identifier
        {
            get { return "user"; }
        }

        public UserScrapper(IWebClient webClient, IHtmlParser htmlParser)
            : base(webClient, htmlParser)
        { }

        protected override void Scrappe(IUser instance)
        {
            var user = new User();

            // TODO
        }
    }
}
