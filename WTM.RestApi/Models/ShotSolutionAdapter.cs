using WTM.Crawler.Domain;

namespace WTM.RestApi.Models
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