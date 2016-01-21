using System.Runtime.Serialization;

namespace WTM.RestApi.Models
{
    [DataContract]
    public class ShotRequest : IShotRequest
    {
        [DataMember]
        public string Token { get; set; }
    }
}