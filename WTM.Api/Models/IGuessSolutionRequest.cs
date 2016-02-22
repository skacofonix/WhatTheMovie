namespace WTM.Api.Models
{
    public interface IGuessSolutionRequest : IRequest, IAuthenticable
    {
        string Title { get; set; }
    }
}