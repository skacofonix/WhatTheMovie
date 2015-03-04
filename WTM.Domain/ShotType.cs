using System.Runtime.Serialization;

namespace WTM.Domain
{
    [DataContract]
    public enum ShotType
    {
        Archive,

        FeatureFilms,

        NewSubmissions,

        Rejected
    }
}