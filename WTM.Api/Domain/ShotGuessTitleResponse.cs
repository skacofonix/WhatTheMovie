using System.Runtime.Serialization;
using WTM.Domain;

namespace WTM.Api.Domain
{
    [DataContract]
    public class ShotGuessTitleResponse : ResponseBase
    {
        [DataMember(EmitDefaultValue = false)]
        public GuessTitleResponse GuessTitleResponse { get; set; }
    }
}