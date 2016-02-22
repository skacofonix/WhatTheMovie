namespace WTM.Api.Models
{
    public interface IShotSolutionResponse : IResponse
    {
        bool Available { get; }

        IShotMovieSolution ShotMovieSolution { get; }
    }
}