using System.Runtime.Serialization;

namespace WTM.Domain.OldSchool
{
    [DataContract]
    public class ShotRateResponse : ResponseBase
    {
        [DataMember(EmitDefaultValue = false)]
        public Rate Rate { get; set; }
    }
}