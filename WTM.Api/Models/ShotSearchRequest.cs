using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace WTM.Api.Models
{
    [DataContract]
    public class ShotSearchRequest : IShotSearchRequest
    {
        [Required]
        [MinLength(3)]
        [DataMember]
        public string Tag { get; }

        [DataMember]
        public int? Start { get; }

        [DataMember]
        public int? Limit { get; }

        [DataMember]
        public string Token { get; }
    }
}