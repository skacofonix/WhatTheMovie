namespace WTM.Api.Models
{
    public class ShotTagDeleteResponse : IShotTagDeleteResponse
    {
        public ShotTagDeleteResponse(bool success)
        {
            Success = success;
        }

        public bool Success { get; }
    }
}