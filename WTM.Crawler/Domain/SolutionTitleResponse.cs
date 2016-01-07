namespace WTM.Crawler.Domain
{
    public class SolutionTitleResponse
    {
        public bool Available { get; set; }
        public int ShotId { get; set; } 
        public string MovieId { get; set; }
        public string OriginalTitle { get; set; }
        public int? Year { get; set; }
    }
}