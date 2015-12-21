using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WTM.Crawler;
using WTM.Crawler.Domain;
using WTM.Domain.Response;
using WTM.RestApi.Services;

namespace WTM.RestApi.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController()
        {
            this.userService = new UserService(new Crawler.Services.UserService(new WebClientWTM(), new HtmlParser()));
        }

        [Route("login")]
        [HttpPost]
        public LoginResponse Login(string username, string password)
        {
            var token = this.userService.Login(username, password);

            var loginResponse = new LoginResponse();
            loginResponse.Data.Token = token;

            return loginResponse;
        }

        [Route("logout")]
        [HttpGet]
        public LogoutResponse Logout([FromBody] string token)
        {
            this.userService.Logout(token);

            var logoutResponse = new LogoutResponse();

            return logoutResponse;
        }

        [HttpGet]
        public HttpResponseMessage Get(string username)
        {
            User item;

            try
            {
                item = this.userService.GetUserByName(username);
            }
            catch (Exception ex)
            {
                var message = $"Error occured on Get User method with username {username}. {ex.Message}";
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, message);
            }

            if (item == null)
            {
                var message = $"User with name {username} not found";
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, item);
        }

        [Route("search")]
        [HttpGet]
        public IEnumerable<User> Search([FromUri]string filter, [FromUri]int? start = null, [FromUri]int? limit = null)
        {
            return null;
        }
    }
}