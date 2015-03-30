using System.Runtime.Serialization;

namespace WTM.Domain
{
    [DataContract]
    public class ShotSearchResult : ResponseBase
    {
        [DataMember(EmitDefaultValue = false)]
        public ShotSummaryCollection ShotSummaries { get; set; }
    }
}