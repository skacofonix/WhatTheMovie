using System.Collections.Generic;

namespace WTM.Api.Domain
{
    public interface IResponse
    {
        IList<Error> Errors { get; }

        void AddError(Error error);
    }
}