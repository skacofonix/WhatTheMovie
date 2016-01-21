using System.Runtime.Serialization;

namespace WTM.RestApi.Models
{
    public interface IAuthenticable
    {
        [DataMember]
        string Token { get; }
    }
}
