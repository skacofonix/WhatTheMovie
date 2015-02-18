using WTM.Domain.Interfaces;

namespace WTM.Domain
{
    public class Range : IRange
    {
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
    }
}