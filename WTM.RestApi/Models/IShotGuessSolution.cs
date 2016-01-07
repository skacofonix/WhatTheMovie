namespace WTM.RestApi.Models
{
    public interface IShotGuessSolution : IResponse, ISuccessable
    {
        IMovieSolution MovieSolution { get; }
    }
}