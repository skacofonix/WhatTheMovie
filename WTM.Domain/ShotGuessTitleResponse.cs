using System.Runtime.Serialization;

namespace WTM.Domain
{
    [DataContract]
    public class ShotGuessTitleResponse : ResponseBase
    {
        [DataMember(EmitDefaultValue = false)]
        public GuessTitleResponse GuessTitleResponse { get; set; }
    }
}