using System;
using System.Collections.Generic;
using WTM.Domain.Interfaces;

namespace WTM.Domain
{
    public class Settings : ISettings
    {
        public DateTime ParseDateTime { get; set; }
        
        public TimeSpan ParseDuration { get; set; }
        
        public IList<ParseInfo> ParseInfos { get; set; }

        #region Filters

        public bool? ShowGore { get; set; }

        public bool? ShowNudity { get; set; }

        #endregion

        public Settings()
        {
            ParseDateTime = DateTime.Now;            
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
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
