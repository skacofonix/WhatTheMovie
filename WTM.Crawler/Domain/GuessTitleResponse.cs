namespace WTM.Crawler.Domain
{
    public class GuessTitleResponse
    {
        public bool RightGuess { get; set; }
        public int ShotId { get; set; } 
        public string MovieId { get; set; }
        public string OriginalTitle { get; set; }
        public int? Year { get; set; }
    }
}