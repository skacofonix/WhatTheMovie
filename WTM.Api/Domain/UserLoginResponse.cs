using System.Runtime.Serialization;
using WTM.Api.Domain;

namespace WTM.Api.Controllers
{
    [DataContract]
    public class UserLoginResponse : ResponseBase
    {
        [DataMember(EmitDefaultValue = false)]
        public string Token { get; set; }
    }
}