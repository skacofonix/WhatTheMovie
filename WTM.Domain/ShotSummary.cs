using System.Runtime.Serialization;
using WTM.Domain.Interfaces;

namespace WTM.Domain
{
    [DataContract]
    public class ShotSummary : IShotSummary
    {
        [DataMember(IsRequired = true, Order = 1)]
        public int ShotId { get; set; }

        [DataMember(IsRequired = true, Order = 2)]
        public string ImageUrl { get; set; }

        [DataMember(IsRequired = true, Order = 3)]
        public ShotUserStatus UserStatus { get; set; }
    }
}