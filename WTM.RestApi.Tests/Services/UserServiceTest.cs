using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WTM.Crawler;
using WTM.RestApi.Controllers.Models;
using WTM.RestApi.Services;

namespace WTM.RestApi.Tests.Services
{
    [TestFixture]
    public class UserServiceTest
    {
        [Test]
        public void ShouldSearchUser()
        {
            var userService = new UserService(new Crawler.Services.UserService(new WebClientWTM(), new HtmlParser()));

            userService.Search(new UserSearchRequest {Filter = "ama"});
        }
    }
}
