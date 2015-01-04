namespace WTM.Core.Services
{
    internal class ShowSolutionResponse
    {
        public string OriginalTitle { get; private set; }
        public int? Year { get; private set; }
        public string MovieLink { get; private set; }

        public ShowSolutionResponse(string originalTitle, int year, string movieLink)
        {
            OriginalTitle = originalTitle;
            Year = year;
            MovieLink = movieLink;
        }
    }
}
