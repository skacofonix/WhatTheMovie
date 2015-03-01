using System;
using System.Net;
using System.Web.Http;
using WTM.Core.Services;
using WTM.Domain;
using WTM.WebsiteClient;
using WTM.WebsiteClient.Services;

namespace WTM.Api.Controllers
{
    public class ShotController : ApiController
    {
        private readonly IShotService shotService;

        public ShotController()
        {
            var webClient = new WebClientWTM();
            var htmlParser = new HtmlParser();
            shotService = new ShotService(webClient, htmlParser);
        }

        public ShotController(IShotService shotService)
        {
            this.shotService = shotService;
        }

        public Shot Get()
        {
            return Random();
        }

        public Shot Get(int id)
        {
            return shotService.GetShotById(id);
        }

        [ActionName("Random")]
        public Shot Random()
        {
            return shotService.GetRandomShot();
        }

        [HttpGet]
        [ActionName("Guess")]
        public GuessTitleResponse Guess(int id, string title)
        {
            // Don't forget fucking guillmet lorsque l'on forge la trame sous fidler
            // Content-Type: application/json

            return shotService.GuessTitle(id, WebUtility.UrlDecode(title));
        }

        [HttpGet]
        [ActionName("Rate")]
        public Rate Rate(int id, int score)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [ActionName("AddBookmark")]
        public bool AddBookmark(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [ActionName("RemoveBookmark")]
        public bool RemoveBookmark(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [ActionName("AddFavourite")]
        public bool AddFavourite(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [ActionName("RemoveFavourite")]
        public bool RemoveFavourite(int id)
        {
            throw new NotImplementedException();
        }
    }
}