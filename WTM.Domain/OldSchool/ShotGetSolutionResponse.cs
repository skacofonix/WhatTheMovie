using System.Runtime.Serialization;

namespace WTM.Domain.OldSchool
{
    [DataContract]
    public class ShotGetSolutionResponse : ResponseBase
    {
        [DataMember(EmitDefaultValue = false)]
        public GuessTitleResponse GuessTitleResponse { get; set; }
    }
}