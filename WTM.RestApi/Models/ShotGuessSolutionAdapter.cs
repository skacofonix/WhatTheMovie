using WTM.Crawler.Domain;

namespace WTM.RestApi.Models
{
    internal class ShotGuessSolutionAdapter : IShotGuessSolution
    {
        private GuessTitleResponse guessTitleResponsePage;

        public ShotGuessSolutionAdapter(GuessTitleResponse guessTitleResponsePage)
        {
            this.guessTitleResponsePage = guessTitleResponsePage;
        }
    }
}