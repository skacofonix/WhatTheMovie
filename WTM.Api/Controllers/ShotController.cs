using System;
using System.Web.Http;
using WTM.Api.Core.Services;
using WTM.Domain;

namespace WTM.Api.Controllers
{
    public class ShotController : ApiController
    {
        private readonly WTM.Api.Core.Services.IShotService shotService;

        public ShotController()
        {
            //var context = new Context();
            //shotService = new ShotService(context);
        }

        public Shot Get()
        {
            //return (Shot)shotService.GetRandomShot();

            throw new NotImplementedException();
        }

        public Shot Get(int id)
        {
            //return (Shot)shotService.GetShotById(id);

            throw new NotImplementedException();

        }

        public Shot Random()
        {
            //return (Shot)shotService.GetRandomShot();

            throw new NotImplementedException();

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