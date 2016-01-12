using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WTM.Crawler.Domain
{
    [DataContract]
    public class Settings : IWebsiteEntity
    {
        [IgnoreDataMember]
        public DateTime ParseDateTime { get; set; }

        [IgnoreDataMember]
        public TimeSpan ParseDuration { get; set; }

        [IgnoreDataMember]
        public IList<ParseInfo> ParseInfos { get; set; }

        public string ConnectedUsername { get; set; }

        [DataMember]
        public bool? ShowGore { get; set; }

        [DataMember]
        public bool? ShowNudity { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Settings) obj);
        }

        protected bool Equals(Settings other)
        {
            return ShowGore.Equals(other.ShowGore)
                && ShowNudity.Equals(other.ShowNudity);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = ParseDateTime.GetHashCode();
                hashCode = (hashCode * 397) ^ ShowGore.GetHashCode();
                hashCode = (hashCode * 397) ^ ShowNudity.GetHashCode();
                return hashCode;
            }
        }
    }
}