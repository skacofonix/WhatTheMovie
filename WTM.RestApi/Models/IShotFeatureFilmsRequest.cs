using System;

namespace WTM.RestApi.Models
{
    public interface IShotFeatureFilmsRequest : IRequest, IPaginableRequest, IAuthenticable
    {
        DateTime? Date { get; }
    }
}