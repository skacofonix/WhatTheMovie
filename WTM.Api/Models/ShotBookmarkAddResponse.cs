namespace WTM.Api.Models
{
    public class ShotBookmarkAddResponse : IShotBookmarkAddResponse
    {
        public ShotBookmarkAddResponse(bool success)
        {
            this.Success = success;
        }

        public bool Success { get; }
    }
}