using WTM.RestApi.Models;

namespace WTM.RestApi.Services
{
    public interface IShotService
    {
        IShotResponse GetById(int id, ShotRequest request);
        IShotResponse GetRandom(ShotRandomRequest request);
        IShotGuessSolution GuessSolution(int id, GuessSolutionRequest request);
        IShotSolutionResponse GetSolution(int id, ShotSolutionRequest request);
    }
}