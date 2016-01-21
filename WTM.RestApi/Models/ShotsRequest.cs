using System;
using System.Runtime.Serialization;

namespace WTM.RestApi.Models
{
    public interface IShotsRequest : IRequest, IPaginableRequest, IAuthenticable
    {
        [DataMember]
        DateTime? Date { get; }
    }

    [DataContract]
    public class ShotsRequest : IShotsRequest
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