using WTM.RestApi.Models;

namespace WTM.RestApi.Services
{
    public interface IShotService
    {
        ShotResponse GetById(int id, string token = null);
        ShotResponse GetRandom(string token = null);
        IShotGuessSolution GuessSolution(int id, string title, string token = null);
        ShotSolutionResponse GetSolution(int id, string token = null);
    }
}