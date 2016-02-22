using System.Runtime.Serialization;

namespace WTM.Api.Models
{
    [DataContract]
    public class ShotMovieSolution : IShotMovieSolution
    {
        [DataMember(IsRequired = true)]
        public string Id { get; set; }

        [DataMember(IsRequired = true)]
        public string Title { get; set; }

        [DataMember(IsRequired = true)]
        public int Year { get; set; }
    }
}