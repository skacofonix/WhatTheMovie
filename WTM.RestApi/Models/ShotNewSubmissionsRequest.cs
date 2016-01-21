using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace WTM.RestApi.Models
{
    [DataContract]
    public class ShotNewSubmissionsRequest : IShotNewSubmissionsRequest
    {
        [DataMember]
        public int? Start { get; set; }

        [DataMember]
        public int? Limit { get; set; }

        [Required]
        [DataMember]
        public string Token { get; set; }
    }
}