using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Http;
using System.Web.Http.Description;
using WTM.Crawler.Domain;
using WTM.RestApi.Models;
using WTM.RestApi.Services;

namespace WTM.RestApi.Controllers
{
    [RoutePrefix("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [Route("{username}")]
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

            if (item?.Name == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [Route("search")]
        [HttpGet]
        [ResponseType(typeof(IUserSearchResponse))]
        public IHttpActionResult Search([FromUri]UserSearchRequest filter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IUserSearchResponse response;
            try
            {
                response = userService.Search(filter);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(response);
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
                loginResponse = new LoginResponse(token);
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