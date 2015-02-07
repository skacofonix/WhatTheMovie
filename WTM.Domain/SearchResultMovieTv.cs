namespace WTM.WebsiteClient.Domain
{
    public class SearchResultMovieTv : SearchResultBase
    {
        public string Title { get; set; }
        public int? Year { get; set; }
        public string MovieUrl { get; set; }
        public bool IsTvSeries { get; set; }
    }
}