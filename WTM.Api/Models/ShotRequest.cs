using System.Runtime.Serialization;

namespace WTM.Api.Models
{
    [DataContract]
    public class ShotRequest : IShotRequest
    {
        [DataMember]
        public string Token { get; }
    }
}