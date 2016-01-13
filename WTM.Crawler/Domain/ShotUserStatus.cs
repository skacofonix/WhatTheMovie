using System.Runtime.Serialization;

namespace WTM.Crawler.Domain
{
    [DataContract]
    public enum ShotUserStatus
    {
        NotConnected,

        Unsolved,

        Solved,

        NeverSolved,

        Uploaded,

        Requested
    }
}