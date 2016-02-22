namespace WTM.Api.Models
{
    public class ShotFavouritesAddResponse : IShotFavouritesAddResponse
    {
        public ShotFavouritesAddResponse(bool success)
        {
            Success = success;
        }

        public bool Success { get; private set; }
    }
}