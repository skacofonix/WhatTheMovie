using System.Runtime.Serialization;

namespace WTM.Domain.OldSchool
{
    [DataContract]
    public class ResponseGeneric<T> : ResponseBase where T : class
    {
        public T Instance { get; set; }
    }
}