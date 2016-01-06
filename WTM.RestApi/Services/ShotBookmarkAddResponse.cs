using WTM.RestApi.Models;

namespace WTM.RestApi.Services
{
    public class ShotBookmarkAddResponse : IResponse, ISuccessable
    {
        public ShotBookmarkAddResponse(bool success)
        {
            this.Success = success;
        }

        public bool Success { get; }
    }
}