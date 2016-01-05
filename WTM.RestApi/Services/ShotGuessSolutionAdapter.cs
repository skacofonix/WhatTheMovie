using WTM.Crawler.Domain;
using WTM.RestApi.Models;

namespace WTM.RestApi.Services
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