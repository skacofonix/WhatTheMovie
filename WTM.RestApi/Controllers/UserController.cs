using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using WTM.Crawler;
using WTM.Crawler.Domain;
using WTM.Domain.Request;
using WTM.Domain.Response;
using WTM.RestApi.Services;

namespace WTM.RestApi.Controllers
{
    [RoutePrefix("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        //private readonly 

        public UserController()
        {
            this.userService = new UserService(new Crawler.Services.UserService(new WebClientWTM(), new HtmlParser()));
        }

        [Route("users/{username}")]
        [HttpGet]
        [ResponseType(typeof(User))]
        public IHttpActionResult Get([Required]string username)
        {
            User item = null;

            if (string.IsNullOrWhiteSpace(username))
            {
                return BadRequest("Username cannot be null or empty");
            }

            try
            {
                item = this.userService.GetUserByName(username);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            if (item == null || item.Name == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [Route("users")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<User>))]
        public IHttpActionResult Get([FromUri]string filter, [FromUri]int? start = null, [FromUri]int? limit = null)
        {
            return InternalServerError(new NotImplementedException("Come back later"));
        }

        [Route("login")]
        [HttpPost]
        [ResponseType(typeof(LoginResponse))]
        public IHttpActionResult Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string token = null;
            LoginResponse loginResponse = null;
            try
            {
                token = this.userService.Login(request.Username, request.Password);
                loginResponse = new LoginResponse();
                loginResponse.Data.Token = token;
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }

            return Ok(loginResponse);
        }

        [Route("logout")]
        [HttpGet]
        [ResponseType(typeof(LogoutResponse))]
        public IHttpActionResult Logout(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                return BadRequest();
            }

            try
            {
                this.userService.Logout(token);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            var logoutResponse = new LogoutResponse();

            return Ok(logoutResponse);
        }
    }
}