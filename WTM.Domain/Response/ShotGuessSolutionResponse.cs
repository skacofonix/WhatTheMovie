namespace WTM.Domain.Response
{
    public class ShotGuessSolutionResponse : ResponseBase<IShotGuessSolution>
    {
        private IShotGuessSolution shotGuessSolution;

        public ShotGuessSolutionResponse(IShotGuessSolution shotGuessSolution)
        {
            this.shotGuessSolution = shotGuessSolution;
        }
    }
}