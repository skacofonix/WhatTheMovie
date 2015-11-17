using System.Runtime.Serialization;

namespace WTM.Domain.OldSchool
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