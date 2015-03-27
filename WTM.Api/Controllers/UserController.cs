using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
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
        public LoginResponse Login([FromUri] string username, [FromUri] string password)
        {
            var token = userService.Login(username, password);

            var loginResponse = new LoginResponse();
            if (token != null)
            {
                loginResponse.Token = token;
            }
            else
            {
                loginResponse.Code = 13;                        // Nawak
                loginResponse.Message = "Wrong authentication"; // Nawak
            }

            return loginResponse;
        }

        [Route("api/User/{username}")]
        [HttpGet]
        public User Get(string username)
        {
            return userService.GetByUsername(username);
        }

        //[Route("api/User/Search")]
        [HttpGet]
        public List<UserSummary> Search(string search, [FromUri]int? page = null)
        {
            return userService.Search(search, page).ToList();
        }
    }
}