
namespace WTM.Api.Core.Adapter
{
    public static class GuessTitleResponseAdapter
    {
        public static Domain.GuessTitleResponse ConvertToCore(WebsiteClient.Services.GuessTitleResponse initialGuessTitleResponse)
        {
            var rightTitleResponse = new Domain.GuessTitleResponse();

            if (initialGuessTitleResponse == null)
            {
                rightTitleResponse.RightGuess = false;
            }
            else
            {
                rightTitleResponse.RightGuess = true;
                rightTitleResponse.MovieId = initialGuessTitleResponse.MovieId;
                rightTitleResponse.OriginalTitle = initialGuessTitleResponse.OriginalTitle;
                rightTitleResponse.Year = initialGuessTitleResponse.Year; 
            }

            return rightTitleResponse;
        }
    }
}