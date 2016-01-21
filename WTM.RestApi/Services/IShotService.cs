using WTM.RestApi.Models;

namespace WTM.RestApi.Services
{
    public interface IShotService
    {
        IShotResponse GetById(int id, IShotRequest request);
        IShotResponse GetRandom(IShotRandomRequest request);
        IShotGuessTitleResponse GuessTitle(int id, IGuessSolutionRequest request);
        IShotSolutionResponse GetSolution(int id, IShotSolutionRequest request);
    }
}