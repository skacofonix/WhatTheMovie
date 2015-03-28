using System.Runtime.Serialization;
using WTM.Domain;

namespace WTM.Api.Domain
{
    [DataContract]
    public class ShotResponse : ResponseBase
    {
        [DataMember(EmitDefaultValue = false)]
        public Shot Shot { get; set; }
    }
}