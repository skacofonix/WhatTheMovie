using WTM.Api.Models;

namespace WTM.Api.Services
{
    public interface IShotService
    {
        IShotResponse GetById(int id, IShotRequest request);
        IShotResponse GetRandom(IShotRandomRequest request);
        IShotGuessTitleResponse GuessTitle(int id, IGuessSolutionRequest request);
        IShotSolutionResponse GetSolution(int id, IShotSolutionRequest request);
    }
}