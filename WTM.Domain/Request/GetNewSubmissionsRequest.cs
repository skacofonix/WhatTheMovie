namespace WTM.Domain.Request
{
    public class GetNewSubmissionsRequest : IPaginableRequest, IAuthenticableRequest
    {
        public int? Limit { get; set; }

        public int? Start { get; set; }

        public string Token { get; set; }
    }
}