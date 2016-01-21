namespace WTM.RestApi.Models
{
    public interface IGuessSolutionRequest : IRequest, IAuthenticable
    {
        string Title { get; set; }
    }
}