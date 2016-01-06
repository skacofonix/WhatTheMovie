using WTM.RestApi.Models;

namespace WTM.RestApi.Services
{
    public class ShotTagAddResponse : IResponse, ISuccessable
    {
        public ShotTagAddResponse(bool success)
        {
            Success = success;
        }

        public bool Success { get; }
    }
}