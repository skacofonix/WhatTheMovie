namespace WTM.Domain
{
    public class SearchResultMovieTv
    {
        public string Title { get; set; }
        public int? Year { get; set; }
        public string MovieUrl { get; set; }
        public bool IsTvSeries { get; set; }
    }
}