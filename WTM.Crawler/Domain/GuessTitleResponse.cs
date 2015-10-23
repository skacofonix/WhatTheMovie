using System.Runtime.Serialization;

namespace WTM.Crawler.Domain
{
    [DataContract]
    public class GuessTitleResponse
    {
        [DataMember(EmitDefaultValue = false)]
        public bool? RightGuess { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string MovieId { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int? ShotId { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string OriginalTitle { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int? Year { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Movie Movie { get; private set; }
    }
}