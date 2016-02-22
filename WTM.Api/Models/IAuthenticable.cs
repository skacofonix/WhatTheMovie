using System.Runtime.Serialization;

namespace WTM.Api.Models
{
    public interface IAuthenticable
    {
        [DataMember]
        string Token { get; }
    }
}