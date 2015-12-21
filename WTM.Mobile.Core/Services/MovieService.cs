using WTM.Domain;
using WTM.Domain.OldSchool;

namespace WTM.Mobile.Core.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieService movieService;

        public MovieService()
        {
            var settings = new SettingsAzure();
            var settingsAdapter = new ApiClientSettingsAdapter(settings);
            movieService = new Api.Client.Services.MovieService(settingsAdapter);
        }

        public Movie GetById(string id)
        {
            return movieService.GetById(id);
        }

        public MovieSummaryCollection Search(string title, int? page = null)
        {
            return movieService.Search(title, page);
        }
    }
}