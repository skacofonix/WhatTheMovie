using System.Runtime.Serialization;
using WTM.Domain.Interfaces;

namespace WTM.Domain
{
    [DataContract]
    public class NewSubmissionSummary : IShotSummary, INewSubmissionSummary
    {
        [DataMember]
        public int ShotId { get; set; }
        
        [DataMember]
        public string ImageUrl { get; set; }
        
        [DataMember]
        public ShotUserStatus UserStatus { get; set; }
        
        [DataMember]
        public IRate Rate { get; private set; }
        
        [DataMember]
        public int TimeRemaining { get; private set; }
    }
}