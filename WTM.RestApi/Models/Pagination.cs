namespace WTM.RestApi.Models
{
    public class Pagination : IPaginableResult
    {
        public Pagination(int totalCount, int displayMin, int displayMax)
        {
            TotalCount = totalCount;
            DisplayMin = displayMin;
            DisplayMax = displayMax;
        }

        public int TotalCount { get; private set; }
        public int DisplayCount => this.DisplayMax - this.DisplayMin;
        public int DisplayMin { get; private set; }
        public int DisplayMax { get; private set; }
    }
}