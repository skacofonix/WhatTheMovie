using System.Runtime.Serialization;

namespace WTM.Domain
{
    [DataContract]
    public class LoginResponse: IResponse
    {
        [DataMember(EmitDefaultValue = false)]
        public int Code { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Message { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Token { get; set; }
    }
}