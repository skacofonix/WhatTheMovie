using WTM.RestApi.Models.Response;

namespace WTM.RestApi.Services
{
    public interface IShoteRateService
    {
        ShotRateResponse Rate(int id, int rate, string token);
    }
}