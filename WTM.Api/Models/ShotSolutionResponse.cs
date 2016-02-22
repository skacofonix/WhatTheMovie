using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using WTM.Crawler.Domain;

namespace WTM.Api.Models
{
    [DataContract]
    public class ShotSolutionResponse : IShotSolutionResponse
    {
        public ShotSolutionResponse(SolutionTitleResponse guessTitleResponse)
        {
            if (guessTitleResponse.Available)
            {
                Available = true;

                ShotMovieSolution = new ShotMovieSolution
                {
                    Id = guessTitleResponse.MovieId,
                    Title = guessTitleResponse.OriginalTitle,
                    Year = guessTitleResponse.Year.Value
                };
            }
        }

        [Required]
        [DataMember]
        public bool Available { get; }

        [DataMember(EmitDefaultValue = false)]
        public IShotMovieSolution ShotMovieSolution { get; }
    }
}