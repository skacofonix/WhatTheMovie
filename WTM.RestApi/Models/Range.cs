namespace WTM.RestApi.Models
{
    public class Range : IRange
    {
        public Range(int min, int max)
        {
            Min = min;
            Max = max;
        }

        public int Min { get; }

        public int Max { get; }
    }
}