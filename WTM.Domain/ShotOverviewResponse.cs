using System.Runtime.Serialization;

namespace WTM.Domain
{
    [DataContract]
    public class ShotOverviewResponse : ResponseBase
    {
        [DataMember(EmitDefaultValue = false)]
        public ShotSummaryCollection ShotsSummaries{ get; set; }
    }
}