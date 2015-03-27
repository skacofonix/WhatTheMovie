using System;
using System.Web.Http;
using WTM.Api.Domain;

namespace WTM.Api.Controllers
{
    public class BaseController : ApiController 
    {
        public T DoWork<T>(Func<T> action) where T : IResponse
        {
            T response;

            try
            {
                response = action();
            }
            catch (Exception ex)
            {
                response = default(T);

                response.AddError(new Error
                {
                    Code = -1,
                    Message = "Error occur",
                    Exception = ex
                });
            }

            return response;
        }
    }
}