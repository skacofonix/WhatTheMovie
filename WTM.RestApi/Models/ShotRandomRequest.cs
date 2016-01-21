using System.Runtime.Serialization;

namespace WTM.RestApi.Models
{
    [DataContract]
    public class ShotRandomRequest : IShotRandomRequest
    {
        [DataMember]
        public string Token { get; }
    }
}