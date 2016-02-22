using System.Runtime.Serialization;

namespace WTM.Api.Models
{
    [DataContract]
    public class ShotSolutionRequest : IShotSolutionRequest
    {
        [DataMember]
        public string Token { get; set; }
    }
}