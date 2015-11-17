using System.Runtime.Serialization;

namespace WTM.Domain.OldSchool
{
    [DataContract]
    public class ShotResponse : ResponseBase
    {
        [DataMember(EmitDefaultValue = false)]
        public Shot Shot { get; set; }
    }
}