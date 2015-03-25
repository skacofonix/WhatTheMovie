using WTM.Core.Services;
using WTM.Domain;
using WTM.Mobile.Core.ViewModels.Parameters;

namespace WTM.Mobile.Core.ViewModels
{
    public class MovieViewModel : ViewModelBase
    {
        private readonly IMovieService movieService;

        public MovieViewModel(IContext context, IMovieService movieService)
            : base(context)
        {
            this.movieService = movieService;
        }

        public void Init(MovieParameters movieParameters = null)
        {
            if (movieParameters != null)
            {
                Movie = movieService.GetById(movieParameters.MovieId);
            }
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