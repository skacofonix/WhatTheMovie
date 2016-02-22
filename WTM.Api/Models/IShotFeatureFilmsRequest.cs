using System;

namespace WTM.Api.Models
{
    public interface IShotFeatureFilmsRequest : IRequest, IPaginableRequest, IAuthenticable
    {
        DateTime? Date { get; }
    }
}