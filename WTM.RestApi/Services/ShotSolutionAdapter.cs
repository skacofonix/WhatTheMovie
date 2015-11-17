using WTM.Crawler.Domain;
using WTM.Domain;

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