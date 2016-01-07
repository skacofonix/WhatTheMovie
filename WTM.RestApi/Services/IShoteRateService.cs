using WTM.RestApi.Models;

namespace WTM.RestApi.Services
{
    public interface IShoteRateService
    {
        ShotRateResponse Rate(RateRequest request);
    }
}