using System;
using System.Collections.Generic;
using WTM.Core.Adapter;
using WTM.Domain;
using WTM.WebsiteClient.Application.Parsers;
using GuessTitleResponse = WTM.Domain.GuessTitleResponse;

namespace WTM.Core.Services
{
    public class ShotService : IShotService
    {
        private readonly ShotParser shotParser;
        private readonly ShotAdapter shotAdapter;
        private readonly WebsiteClient.Services.ShotService shotService;

        public ShotService(IContext context)
        {
            shotParser = new ShotParser(context.WebClient, context.HtmlParser);
            shotAdapter = new ShotAdapter();
            shotService = new WebsiteClient.Services.ShotService(context.WebClient, context.HtmlParser);
        }

        public Shot GetRandomShot()
        {
            return ShotAdapter.ConvertToCore(shotParser.ParseRandom());
        }

        public Shot GetShotById(int id)
        {
            return ShotAdapter.ConvertToCore(shotParser.Parse(id));
        }

        public Shot GetFirstShot(Shot currentShot = null)
        {
            throw new NotImplementedException();
        }

        public Shot GetPreviousShot(Shot currentShot)
        {
            throw new NotImplementedException();
        }

        public Shot GetPreviousUnsolvdShot(Shot currentShot)
        {
            throw new NotImplementedException();
        }

        public Shot GetNextUnsolvedShot(Shot currentShot)
        {
            throw new NotImplementedException();
        }

        public Shot GetNextShot(Shot currentShot)
        {
            throw new NotImplementedException();
        }

        public Shot GetLastShotShot(Shot currentShot = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Shot> Search(string tag)
        {
            throw new NotImplementedException();
        }

        public GuessTitleResponse GuessTitle(int shotId, string title)
        {
            var result = shotService.GuessTitle(shotId, title);
            return GuessTitleResponseAdapter.ConvertToCore(result);
        }

        public bool ShowSolution(Shot shot)
        {
            throw new NotImplementedException();
        }

        public bool Rate(int score)
        {
            throw new NotImplementedException();
        }
    }
}