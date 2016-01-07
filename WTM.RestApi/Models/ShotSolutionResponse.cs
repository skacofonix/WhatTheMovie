using System.Runtime.Serialization;
using WTM.Crawler.Domain;

namespace WTM.RestApi.Models
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

        [DataMember]
        public bool Available { get; }

        [DataMember(EmitDefaultValue = false)]
        public IShotMovieSolution ShotMovieSolution { get; }
    }
}