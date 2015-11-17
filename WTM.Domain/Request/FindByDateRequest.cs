using System;

namespace WTM.Domain.Request
{
    public class FindByDateRequest : IPaginableRequest, IAuthenticableRequest
    {
        public DateTime? Date { get; set; }

        public int? Limit { get; set; }

        public int? Start { get; set; }

        public string Token { get; set; }
    }
}
