using System.Runtime.Serialization;

namespace WTM.Crawler.Domain
{
    [DataContract]
    public class ShotGetSolutionResponse : ResponseBase
    {
        [DataMember(EmitDefaultValue = false)]
        public GuessTitleResponse GuessTitleResponse { get; set; }
    }
}