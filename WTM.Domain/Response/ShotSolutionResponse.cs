namespace WTM.Domain.Response
{
    public class ShotSolutionResponse : ResponseBase<IShotSolution>
    {
        private IShotSolution shotSolution;

        public ShotSolutionResponse(IShotSolution shotSolution)
        {
            this.shotSolution = shotSolution;
        }
    }
}