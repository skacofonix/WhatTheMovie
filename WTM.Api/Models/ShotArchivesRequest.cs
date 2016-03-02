using System;
using System.Runtime.Serialization;

namespace WTM.Api.Models
{
    [DataContract]
    public class ShotArchivesRequest : IShotArchivesRequest
    {
        [DataMember]
        public DateTime? Date { get; set; }

        [DataMember]
        public int? Start { get; set; }

        [DataMember]
        public int? Limit { get; set; }

        [DataMember]
        public string Token { get; set; }
    }
}