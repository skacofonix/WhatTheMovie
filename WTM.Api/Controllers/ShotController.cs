using System;
using System.Web.Http;
using WTM.Core.Services;
using WTM.Domain;

namespace WTM.Api.Controllers
{
    public class ShotController : ApiController
    {
        private readonly IShotService shotService;

        public ShotController(IShotService shotService)
        {
            this.shotService = shotService;
        }

        public Shot Get()
        {
            return (Shot)shotService.GetRandomShot();
        }

        public Shot Get(int id)
        {
            return (Shot)shotService.GetShotById(id);
        }

        public Shot Random()
        {
            return (Shot)shotService.GetRandomShot();
        }

        public GuessTitleResponse GuessTitle(int id, [FromBody]string guessTitle)
        {
            // Don't forget fucking guillmet lorsque l'on forge la trame sous fidler
            // Content-Type: application/json

            return (GuessTitleResponse)shotService.GuessTitle(id, guessTitle);
        }

        public Rate Rate(int id, [FromBody] int score)
        {
            throw new NotImplementedException();
        }

        public bool AddBookmark(int id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveBookmark(int id)
        {
            throw new NotImplementedException();
        }

        public bool AddFavourite(int id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveFavourite(int id)
        {
            throw new NotImplementedException();
        }
    }
}