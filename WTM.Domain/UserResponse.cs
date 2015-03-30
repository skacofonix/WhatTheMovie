using System.Runtime.Serialization;

namespace WTM.Domain
{
    [DataContract]
    public class UserResponse : ResponseBase
    {
        [DataMember(EmitDefaultValue = false)]
        public User User { get; set; }
    }
}