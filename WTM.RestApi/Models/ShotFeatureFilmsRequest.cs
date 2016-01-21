using System;
using System.Runtime.Serialization;

namespace WTM.RestApi.Models
{
    [DataContract]
    public class ShotFeatureFilmsRequest : IShotFeatureFilmsRequest
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