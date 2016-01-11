namespace WTM.RestApi.Models
{
    public class MovieSearchTagResponse : IMovieSearchTagResponse
    {
        public int DisplayCount { get; }
        public int TotalCount { get; }
        public IRange DisplayRange { get; }
    }
}