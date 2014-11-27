using WTM.CorePCL.Domain.WebsiteEntities;

namespace WTM.CorePCL.Application
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

        protected override IUser Scrappe()
        {
            var user = new User();

            // TODO

            return user;
        }
    }
}
