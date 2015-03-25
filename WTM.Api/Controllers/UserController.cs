﻿using System.Web.Http;
using WTM.Core.Services;
using WTM.Crawler;
using WTM.Crawler.Services;
using WTM.Domain;

namespace WTM.Api.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserService userService;

        public UserController()
        {
            var webClient = new WebClientWTM();
            var htmlParser = new HtmlParser();
            userService = new UserService(webClient, htmlParser);
        }

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        // GET api/User/Login?username={username}&password={password}
        [Route("api/User/Login")]
        [HttpGet]
        public User Login([FromUri]string username, [FromUri]string password)
        {
            return userService.Login(username, password);
        }
    }
}