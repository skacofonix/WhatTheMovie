using System.Runtime.Serialization;

namespace WTM.Api.Models
{
    public interface ISuccessable
    {
        [DataMember(IsRequired = true)]
        bool Success { get; }
    }
}