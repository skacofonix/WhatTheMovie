using System.Runtime.Serialization;

namespace WTM.Domain
{
    [DataContract]
    public class ShotRateResponse : ResponseBase
    {
        [DataMember(EmitDefaultValue = false)]
        public Rate Rate { get; set; }
    }
}