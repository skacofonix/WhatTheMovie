using System.Collections.Generic;
using System.Runtime.Serialization;
using WTM.Domain;

namespace WTM.Api.Domain
{
    [DataContract]
    public class UserSearchResponse : ResponseBase
    {
        [DataMember(EmitDefaultValue = false)]
        public List<UserSummary> UserSummaries { get; set; }
    }
}