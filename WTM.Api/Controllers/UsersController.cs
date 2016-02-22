using System;
using System.Web.Http;
using System.Web.Http.Description;
using WTM.Api.Models;
using WTM.Api.Services;

namespace WTM.Api.Controllers
{
    [RoutePrefix("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [Route("{username}")]
        [HttpGet]   
        [ResponseType(typeof(UserResponse))]
        public IHttpActionResult Get(string username) 
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return BadRequest("Username cannot be null or empty");
            }

            IUserResponse result = null;
            try
            {
                result = this.userService.Get(username);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            if (result?.User?.Name == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [Route("search")]
        [HttpGet]
        [ResponseType(typeof(UserSearchResponse))]
        public IHttpActionResult Search([FromUri]IUserSearchRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IUserSearchResponse response;
            try
            {
                response = userService.Search(request);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(response);
        }

        [Route("login")]
        [HttpPost]
        [ResponseType(typeof(UserLoginResponse))]
        public IHttpActionResult Login(UserLoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IUserLoginResponse userLoginResponse = null;
            try
            {
                userLoginResponse = this.userService.Login(request);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            if (userLoginResponse?.Token == null)
            {
                return Unauthorized();
            }

            return Ok(userLoginResponse);
        }

        [Route("logout")]
        [HttpGet]
        [ResponseType(typeof(UserLogoutResponse))]
        public IHttpActionResult Logout(UserLogoutRequest request)
        {
            if (string.IsNullOrEmpty(request.Token))
            {
                return BadRequest();
            }

            IUserLogoutResponse response = null;
            try
            {
                response = this.userService.Logout(request);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(response);
        }
    }
}