using System.Runtime.Serialization;
using WTM.Domain;

namespace WTM.Api.Domain
{
    [DataContract]
    public class UserResponse : ResponseBase
    {
        [DataMember(EmitDefaultValue = false)]
        public User User { get; set; }
    }
}