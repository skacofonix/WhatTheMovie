namespace WTM.Api.Models
{
    public class ShotBookmarkDeleteResponse : IShotBookmarkDeleteResponse
    {
        public ShotBookmarkDeleteResponse(bool success)
        {
            this.Success = success;
        }

        public bool Success { get; private set; }
    }
}