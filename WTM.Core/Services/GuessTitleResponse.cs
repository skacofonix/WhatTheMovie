namespace WTM.Core.Services
{
    internal class GuessTitleResponse
    {
        public string Guess { get; private set; }
        public int? MovieId { get; private set; }
        public string OriginalTitle { get; private set; }
        public int? Year { get; private set; }

        public GuessTitleResponse(string guess, int movieId, string originalTitle, int year)
        {
            Guess = guess;
            MovieId = movieId;
            OriginalTitle = originalTitle;
            Year = year;
        }
    }
}
