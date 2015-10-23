using System;
using System.Collections.Generic;

namespace WTM.Crawler.Domain
{
    public class DifficultyOptions : IWebsiteEntity
    {
        public DateTime ParseDateTime { get; set; }

        public TimeSpan ParseDuration { get; set; }

        public IList<ParseInfo> ParseInfos { get; set; }

        public SnapshotDifficultyChoice SnapshotDifficultyFilter { get; set; }

        public int? NumberOfShotEasy { get; set; }
        
        public int? NumberOfShotMedium { get; set; }
        
        public int? NumberOfShotHard { get; set; }

        public string TagFilter { get; set; }

        public bool IncludeArchive { get; set; }

        public bool IncludeSolvedShots { get; set; }
    }
}