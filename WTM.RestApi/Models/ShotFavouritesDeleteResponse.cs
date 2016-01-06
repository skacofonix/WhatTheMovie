namespace WTM.RestApi.Models
{
    public class ShotFavouritesDeleteResponse : IResponse, ISuccessable
    {
        public ShotFavouritesDeleteResponse(bool success)
        {
            Success = success;
        }

        public bool Success { get; private set; }
    }
}