namespace WTM.RestApi.Models
{
    public class ShotFavouritesAddResponse : IResponse, ISuccessable
    {
        public ShotFavouritesAddResponse(bool success)
        {
            Success = success;
        }

        public bool Success { get; private set; }
    }
}