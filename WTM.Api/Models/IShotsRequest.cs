using System;
using System.Runtime.Serialization;

namespace WTM.Api.Models
{
    public interface IShotsRequest : IRequest, IPaginableRequest, IAuthenticable
    {
        DateTime? Date { get; }
    }
}