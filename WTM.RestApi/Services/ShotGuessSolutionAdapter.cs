using WTM.Crawler.Domain;
using WTM.Domain;

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