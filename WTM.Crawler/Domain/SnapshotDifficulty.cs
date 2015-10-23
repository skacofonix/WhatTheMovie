using System;
using System.Runtime.Serialization;

namespace WTM.Crawler.Domain
{
    [DataContract]
    [Flags]
    public enum SnapshotDifficulty
    {
        Easy = 1,

        Medium = 2,

        Hard = 4
    }
}