using Cirrious.MvvmCross.ViewModels;
using WTM.Core.Services;
using WTM.Domain;

namespace WTM.Mobile.Core.ViewModels
{
    public class MovieViewModel : MvxViewModel
    {
        private readonly IMovieService movieService;

        public MovieViewModel(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        public void Init(string movieId)
        {
            Movie = movieService.GetById(movieId);
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
