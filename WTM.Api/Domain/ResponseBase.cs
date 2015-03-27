using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WTM.Api.Domain
{
    [DataContract]
    public class ResponseBase : IResponse
    {
        [DataMember(EmitDefaultValue = false)]
        public IList<Error> Errors { get; private set; }

        public void AddError(Error error)
        {
            if(Errors == null)
                Errors = new List<Error>();

            Errors.Add(error);
        }
    }
}