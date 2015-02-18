using System.Runtime.Serialization;
using WTM.Domain.Interfaces;

namespace WTM.Domain
{
    [DataContract]
    public class GuessTitleResponse : IGuessTitleResponse
    {
        [DataMember(EmitDefaultValue = false)]
        public bool? RightGuess { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string MovieId { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string OriginalTitle { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int? Year { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public IMovie Movie { get; private set; }
    }
}