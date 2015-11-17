using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WTM.Domain.OldSchool
{
    [DataContract]
    public class UserSearchResponse : ResponseBase
    {
        [DataMember(EmitDefaultValue = false)]  
        public List<UserSummary> UserSummaries { get; set; }
    }
}