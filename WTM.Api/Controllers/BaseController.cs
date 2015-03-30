using System;
using System.Web.Http;
using WTM.Api.Domain;

namespace WTM.Api.Controllers
{
    public class BaseController : ApiController 
    {
        protected static T DoWork<T>(Func<T> action) where T : IResponse
        {
            T response;

            try
            {
                response = action();
            }
            catch (Exception ex)
            {
                response = default(T);

                var message = "Error occur";
                if (!string.IsNullOrEmpty(ex.Message))
                    message += ". " + ex.Message;

                response.AddError(new Error
                {
                    Code = -1,
                    Message = message,
#if DEBUG
                    Exception = ex
#endif
                });
            }

            return response;
        }
    }
}