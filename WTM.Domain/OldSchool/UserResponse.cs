using System.Runtime.Serialization;

namespace WTM.Domain.OldSchool
{
    [DataContract]
    public class UserResponse : ResponseBase
    {
        [DataMember(EmitDefaultValue = false)]
        public User User { get; set; }
    }
}