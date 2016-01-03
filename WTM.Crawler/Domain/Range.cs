namespace WTM.Crawler.Domain
{
    public class Range
    {
        public Range()
        {
            
        }

        public Range(int minValue, int maxValue)
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }

        public int MinValue { get; set; }
        public int MaxValue { get; set; }
    }
}