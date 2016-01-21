using System.Runtime.Serialization;

namespace WTM.RestApi.Models
{
    [DataContract]
    public class ShotSolutionRequest : IShotSolutionRequest
    {
        [DataMember]
        public string Token { get; set; }
    }
}