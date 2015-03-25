using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WTM.Core.Services;
using WTM.Crawler;
using WTM.Crawler.Services;

namespace WTM.Api.Controllers
{
    public class AccountController : ApiController
    {
        private readonly IAuthenticateService authenticateService;

        public AccountController()
        {
            var webClient = new WebClientWTM();
            var htmlParser = new HtmlParser();
            authenticateService = new AuthenticateService(webClient, htmlParser);
        }

        public AccountController(IAuthenticateService authenticateService)
        {
            this.authenticateService = authenticateService;
        }

        [HttpGet]
        public string Login([FromUri]string username, [FromUri]string password)
        {
            return authenticateService.Login(username, password);
        }
    }
}