namespace WTM.RestApi.Models
{
    public class ShotSolutionResponse : IResponse
    {
        private IShotSolution shotSolution;

        public ShotSolutionResponse(IShotSolution shotSolution)
        {
            this.shotSolution = shotSolution;
        }
    }
}