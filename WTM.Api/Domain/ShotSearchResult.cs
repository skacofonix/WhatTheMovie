using System.Runtime.Serialization;
using WTM.Domain;

namespace WTM.Api.Domain
{
    [DataContract]
    public class ShotSearchResult : ResponseBase
    {
        [DataMember(EmitDefaultValue = false)]
        public ShotSummaryCollection ShotSummaries { get; set; }
    }
}