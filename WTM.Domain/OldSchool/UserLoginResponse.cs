using System.Runtime.Serialization;

namespace WTM.Domain.OldSchool
{
    [DataContract]
    public class UserLoginResponse : ResponseBase
    {
        [DataMember(EmitDefaultValue = false)]
        public string Token { get; set; }
    }
}