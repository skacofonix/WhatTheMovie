using System.Runtime.Serialization;

namespace WTM.Domain.OldSchool
{
    [DataContract]
    public class ShotSearchResult : ResponseBase
    {
        [DataMember(EmitDefaultValue = false)]
        public ShotSummaryCollection ShotSummaries { get; set; }
    }
}