using System;

namespace WTM.Api.Models
{
    public interface IShotArchivesRequest : IRequest, IPaginableRequest, IAuthenticable
    {
        DateTime? Date { get; }
    }
}