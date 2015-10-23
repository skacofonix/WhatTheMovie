using System.Runtime.Serialization;

namespace WTM.Crawler.Domain
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