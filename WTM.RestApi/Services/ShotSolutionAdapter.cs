using WTM.Crawler.Domain;
using WTM.RestApi.Models;

namespace WTM.RestApi.Services
{
    internal class ShotSolutionAdapter : IShotSolution
    {
        private GuessTitleResponse guessTitleResponsePage;

        public ShotSolutionAdapter(GuessTitleResponse guessTitleResponsePage)
        {
            this.guessTitleResponsePage = guessTitleResponsePage;
        }
    }
}