namespace WTM.WebsiteClient.Services
{
    public class GuessTitleResponse
    {
        public int? MovieId { get; private set; }
        public string OriginalTitle { get; private set; }
        public int? Year { get; private set; }

        public GuessTitleResponse(int movieId, string originalTitle, int year)
        {
            MovieId = movieId;
            OriginalTitle = originalTitle;
            Year = year;
        }
    }
}
