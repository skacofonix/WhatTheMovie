using WTM.Core.Services;
using WTM.Domain;

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

        public void Init(string movieId)
        {
            if (movieId != null)
            {
                ExecuteSyncAction(() =>
                {
                    Movie = movieService.GetById(movieId);
                });
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