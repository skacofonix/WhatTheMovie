namespace WTM.RestApi.Models
{
    public interface IShotSolutionResponse : IResponse
    {
        bool Available { get; }
        IShotMovieSolution ShotMovieSolution { get; }
    }
}