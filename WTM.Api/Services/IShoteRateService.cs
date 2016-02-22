using WTM.Api.Models;

namespace WTM.Api.Services
{
    public interface IShoteRateService
    {
        ShotRateResponse Rate(RateRequest request);
    }
}