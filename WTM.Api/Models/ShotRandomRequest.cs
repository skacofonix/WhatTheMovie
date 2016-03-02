using System.Runtime.Serialization;

namespace WTM.Api.Models
{
    [DataContract]
    public class ShotRandomRequest : IShotRandomRequest
    {
        [DataMember]
        public string Token { get; set; }
    }
}