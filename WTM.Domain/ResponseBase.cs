using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace WTM.Domain
{
    [DataContract]
    public class ResponseBase : IResponse
    {
        [DataMember(EmitDefaultValue = false)]
        public IList<Error> Errors { get; private set; }

        [IgnoreDataMember]
        public bool HasError
        {
            get
            {
                return Errors != null && Errors.Any();
            }
        }

        public void AddError(Error error)
        {
            if(Errors == null)
                Errors = new List<Error>();

            Errors.Add(error);
        }
    }
}