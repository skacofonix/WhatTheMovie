using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTM.Core.Application;
using WTM.Domain;
using WTM.WebsiteClient.Application.Parsers;

namespace WTM.Core.Services
{
    public class ShotService : IShotService
    {
        private readonly IWebClient webClient;
        private readonly ShotParser shotParser;

        protected ShotService(IWebClient webClient, IHtmlParser htmlParser)
        {
            this.webClient = webClient;
            shotParser = new ShotParser(webClient, htmlParser);
        }

        public Shot GetRandomShot()
        {
            return shotParser.ParseRandom();
        }

        public Shot GetShotById(int id)
        {
            throw new NotImplementedException();
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

        public bool GuessTitle(Shot shot, string title)
        {
            throw new NotImplementedException();
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
