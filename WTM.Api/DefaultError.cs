using WTM.Domain;

namespace WTM.Api
{
    public static class DefaultError
    {
        public static readonly Error DefaultApiError =  new Error
                {
                    Code = -1,
                    Message = "Error occured on the server-side API",
                };
    }
}