using System;
using System.Collections.Generic;
using WTM.Api.Core.Adapter;
using WTM.Domain;
using WTM.WebsiteClient.Application.Parsers;

namespace WTM.Api.Core.Services
{
    public class ShotService : IShotService
    {
        private readonly ShotParser shotParser;
        private readonly WebsiteClient.Services.ShotService shotService;

        public ShotService(IContext context)
        {
            shotParser = new ShotParser(context.WebClient, context.HtmlParser);
            shotService = new WebsiteClient.Services.ShotService(context.WebClient, context.HtmlParser);
        }

        public IShot GetRandomShot()
        {
            return ShotAdapter.ConvertToCore(shotParser.ParseRandom());
        }

        public IShot GetShotById(int id)
        {
            return ShotAdapter.ConvertToCore(shotParser.Parse(id));
        }

        public IEnumerable<IShotSummary> GetShotSummary(int start, int lenght)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IShot> Search(string tag)
        {
            throw new NotImplementedException();
        }

        public IGuessTitleResponse GuessTitle(int shotId, string title)
        {
            var result = shotService.GuessTitle(shotId, title);
            return GuessTitleResponseAdapter.ConvertToCore(result);
        }

        public IMovie ShowSolution(int shotId)
        {
            throw new NotImplementedException();
        }

        public IRate Rate(int score)
        {
            throw new NotImplementedException();
        }
    }
}