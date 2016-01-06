using WTM.RestApi.Models;

namespace WTM.RestApi.Services
{
    public class ShotTagDeleteResponse : IResponse, ISuccessable
    {
        public ShotTagDeleteResponse(bool success)
        {
            Success = success;
        }

        public bool Success { get; }
    }
}