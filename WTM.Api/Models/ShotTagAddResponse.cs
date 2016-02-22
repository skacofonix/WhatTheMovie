namespace WTM.Api.Models
{
    public class ShotTagAddResponse : IShotTagAddResponse
    {
        public ShotTagAddResponse(bool success)
        {
            Success = success;
        }

        public bool Success { get; }
    }
}