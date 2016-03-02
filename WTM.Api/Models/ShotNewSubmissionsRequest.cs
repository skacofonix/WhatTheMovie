using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace WTM.Api.Models
{
    [DataContract]
    public class ShotNewSubmissionsRequest : IShotNewSubmissionsRequest
    {
        [DataMember]
        public int? Start { get; }

        [DataMember]
        public int? Limit { get; }

        [Required]
        [DataMember]
        public string Token { get; }
    }
}