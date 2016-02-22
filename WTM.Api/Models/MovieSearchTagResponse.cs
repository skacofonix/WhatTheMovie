namespace WTM.Api.Models
{
    public class MovieSearchTagResponse : IMovieSearchTagResponse
    {
        public int TotalCount { get; }
        public int DisplayCount { get; }
        public int DisplayMin { get; }
        public int DisplayMax { get; }
    }
}