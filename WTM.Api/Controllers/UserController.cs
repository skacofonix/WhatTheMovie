﻿using System.Web.Http;
using WTM.Core.Services;
using WTM.Crawler;
using WTM.Crawler.Services;
using WTM.Domain;
using System.Linq;

namespace WTM.Api.Controllers
{
    public class UserController : BaseController
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
        public UserLoginResponse Login([FromUri] string username, [FromUri] string password)
        {
            return DoWork(() =>
            {
                var response = new UserLoginResponse();

                var token = userService.Login(username, password);

                if (token != null)
                {
                    response.Token = token;
                }
                else
                {
                    response.AddError(new Error
                    {
                        Message = "Wrong authentication"
                    });
                }

                return response;
            });
        }

        // GET api/User/{username}
        [Route("api/User/{username}")]
        [HttpGet]
        public UserResponse Get(string username)
        {
            return DoWork(() =>
            {
                var response = new UserResponse();

                var user = userService.GetByUsername(username);

                if (user != null)
                {
                    response.User = user;
                }
                else
                {
                    response.AddError(new Error
                    {
                        Message = "Unexisting user"
                    });
                }

                return response;
            });
        }

        // GET api/User?search={search}&page={page}
        [HttpGet]
        public UserSearchResponse Search(string search, [FromUri]int? page = null)
        {
            return DoWork(() =>
            {
                var response = new UserSearchResponse();

                var userSummaries = userService.Search(search, page).ToList();

                if (userSummaries.Any())
                {
                    response.UserSummaries = userSummaries;
                }
                else
                {
                    response.AddError(new Error
                    {
                        Message = "No match found"
                    });
                }

                return response;
            });
        }
    }
}