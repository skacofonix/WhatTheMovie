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
        public string Tag { get; set; }

        [DataMember]
        public int? Start { get; set; }

        [DataMember]
        public int? Limit { get; set; }

        [DataMember]
        public string Token { get; set; }
    }
}