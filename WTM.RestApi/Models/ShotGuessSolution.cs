using System.Runtime.Serialization;
using WTM.Crawler.Domain;

namespace WTM.RestApi.Models
{
    [DataContract]
    public class ShotGuessSolution : IShotGuessSolution
    {
        public ShotGuessSolution(GuessTitleResponse guessTitleResponse)
        {
            if (guessTitleResponse.RightGuess)
            {
                this.Success = true;

                this.MovieSolution = new MovieSolution
                {
                    Id = guessTitleResponse.MovieId,
                    Title = guessTitleResponse.OriginalTitle,
                    Year = guessTitleResponse.Year.Value
                };
            }
        }

        [DataMember]
        public bool Success { get; private set; }

        [DataMember(EmitDefaultValue = false)]
        public IMovieSolution MovieSolution { get; private set; }
    }
}