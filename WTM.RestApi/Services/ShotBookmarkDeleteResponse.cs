using WTM.RestApi.Models;

namespace WTM.RestApi.Services
{
    public class ShotBookmarkDeleteResponse : IResponse, ISuccessable
    {
        public ShotBookmarkDeleteResponse(bool success)
        {
            this.Success = success;
        }

        public bool Success { get; private set; }
    }
}