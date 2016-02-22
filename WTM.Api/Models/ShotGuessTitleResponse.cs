using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using WTM.Crawler.Domain;

namespace WTM.Api.Models
{
    [DataContract]
    public class ShotGuessTitleResponse : IShotGuessTitleResponse
    {
        public ShotGuessTitleResponse(GuessTitleResponse guessTitleResponse)
        {
            if (guessTitleResponse.RightGuess)
            {
                this.Success = true;

                this.ShotMovieSolution = new ShotMovieSolution
                {
                    Id = guessTitleResponse.MovieId,
                    Title = guessTitleResponse.OriginalTitle,
                    Year = guessTitleResponse.Year.Value
                };
            }
        }

        [Required]
        public bool Success { get; private set; }

        [DataMember(EmitDefaultValue = false)]
        public IShotMovieSolution ShotMovieSolution { get; private set; }
    }
}