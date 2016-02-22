namespace WTM.Api.Models
{
    public interface IShotGuessTitleResponse : IResponse, ISuccessable
    {
        IShotMovieSolution ShotMovieSolution { get; }
    }
}