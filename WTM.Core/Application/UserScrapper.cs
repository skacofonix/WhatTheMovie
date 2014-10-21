using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        protected override IUser Scrappe()
        {
            var user = new User();

            // TODO

            return user;
        }
    }
}
