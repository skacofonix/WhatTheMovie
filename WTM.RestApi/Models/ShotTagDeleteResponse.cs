namespace WTM.RestApi.Models
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