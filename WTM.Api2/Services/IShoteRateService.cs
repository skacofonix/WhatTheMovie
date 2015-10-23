using WTM.Api2.Models.Response;

namespace WTM.Api2.Services
{
    public interface IShoteRateService
    {
        ShotRateResponse Rate(int id, int rate, string token);
    }
}