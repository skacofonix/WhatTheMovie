using WTM.RestApi.Services;

namespace WTM.RestApi.Models
{
    public class ShotSolutionResponse : IShotSolutionResponse
    {
        public ShotSolutionResponse(IShotSolution shotSolution)
        {
            this.ShotSolution = shotSolution;
        }

        public IShotSolution ShotSolution { get; private set; }
    }
}