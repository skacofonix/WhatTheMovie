using System;
using System.Runtime.Serialization;

namespace WTM.Api.Models
{
    [DataContract]
    public class ShotFeatureFilmsRequest : IShotFeatureFilmsRequest
    {
        [DataMember]
        public DateTime? Date { get; }

        [DataMember]
        public int? Start { get; }

        [DataMember]
        public int? Limit { get; }

        [DataMember]
        public string Token { get; }
    }
}