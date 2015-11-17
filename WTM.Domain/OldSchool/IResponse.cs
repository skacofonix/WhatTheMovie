using System.Collections.Generic;

namespace WTM.Domain.OldSchool
{
    public interface IResponse
    {
        IList<Error> Errors { get; }

        bool HasError { get; }

        void AddError(Error error);
    }
}