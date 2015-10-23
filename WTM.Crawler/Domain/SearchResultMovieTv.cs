using System.Runtime.Serialization;

namespace WTM.Crawler.Domain
{
    [DataContract]
    public class SearchResultMovieTv
    {
        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public int? Year { get; set; }

        [DataMember]
        public string MovieUrl { get; set; }

        [DataMember]
        public bool IsTvSeries { get; set; }
    }
}