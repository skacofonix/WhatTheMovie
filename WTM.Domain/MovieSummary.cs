using System;
using System.Runtime.Serialization;
using WTM.Domain.Interfaces;

namespace WTM.Domain
{
    [DataContract]
    public class MovieSummary : IMovieSummary
    {
        [DataMember]
        public string MovieId { get; private set; }

        [DataMember]
        public string OriginalTitle { get; private set; }

        [DataMember]
        public int? Year { get; private set; }

        [DataMember]
        public Uri Image { get; private set; }
    }
}
