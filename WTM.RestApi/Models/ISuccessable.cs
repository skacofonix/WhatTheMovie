using System.Runtime.Serialization;

namespace WTM.RestApi.Models
{
    public interface ISuccessable
    {
        [DataMember(IsRequired = true)]
        bool Success { get; }
    }
}