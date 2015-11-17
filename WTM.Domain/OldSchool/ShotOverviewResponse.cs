using System.Runtime.Serialization;

namespace WTM.Domain.OldSchool
{
    [DataContract]
    public class ShotOverviewResponse : ResponseBase
    {
        [DataMember(EmitDefaultValue = false)]
        public ShotSummaryCollection ShotsSummaries{ get; set; }
    }
}