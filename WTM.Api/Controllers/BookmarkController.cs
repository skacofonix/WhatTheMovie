using System;
using System.Web.Http;
using WTM.Core.Services;
using WTM.Crawler;
using WTM.Crawler.Services;
using WTM.Domain;
using System.Collections.Generic;

namespace WTM.Api.Controllers
{
    public class BookmarkController : ApiController
    {
        private readonly IUserService userService;

        public BookmarkController()
        {
            var webClient = new WebClientWTM();
            var htmlParser = new HtmlParser();
            userService = new UserService(webClient, htmlParser);
        }

        public BookmarkController(IUserService userService)
        {
            this.userService = userService;
        }

        // GET api/bookmark
        public IEnumerable<Bookmark> Get()
        {
            throw new NotImplementedException();
        }

        // POST api/bookmark
        public void Post([FromBody]int id)
        {
            throw new NotImplementedException();
        }

        // DELETE api/bookmark/{id}
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}