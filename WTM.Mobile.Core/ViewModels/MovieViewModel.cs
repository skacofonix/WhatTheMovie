using Cirrious.MvvmCross.ViewModels;
using WTM.Core.Services;
using WTM.Domain;
using WTM.Mobile.Core.ViewModels.Parameters;

namespace WTM.Mobile.Core.ViewModels
{
    public class MovieViewModel : MvxViewModel
    {
        private readonly IMovieService movieService;

        public MovieViewModel(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        public void Init()
        {
            // Just for test
        }

        public void Init(MovieParameters movieParameters)
        {
            Movie = movieService.GetById(movieParameters.MovieId);
        }

        public Movie Movie
        {
            get { return movie; }
            set
            {
                movie = value; 
                RaisePropertyChanged(() => Movie);
            }
        }
        private Movie movie;
    }
}
