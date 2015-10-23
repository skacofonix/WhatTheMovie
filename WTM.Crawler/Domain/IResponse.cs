using System.Collections.Generic;

namespace WTM.Crawler.Domain
{
    public interface IResponse
    {
        IList<Error> Errors { get; }

        bool HasError { get; }

        void AddError(Error error);
    }
}