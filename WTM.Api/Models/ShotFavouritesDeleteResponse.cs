namespace WTM.Api.Models
{
    public class ShotFavouritesDeleteResponse : IShotFavouritesDeleteResponse
    {
        public ShotFavouritesDeleteResponse(bool success)
        {
            Success = success;
        }

        public bool Success { get; private set; }
    }
}