using System;
using WTM.Domain.Interfaces;

namespace WTM.Domain
{
    public class DifficultyOptions : IDifficultyOptions
    {
        public DateTime ParseDateTime { get; set; }

        public TimeSpan ParseDuration { get; set; }
        
        public ISnapshotDifficultyChoice SnapshotDifficultyFilter { get; set; }

        public int? NumberOfShotEasy { get; set; }
        
        public int? NumberOfShotMedium { get; set; }
        
        public int? NumberOfShotHard { get; set; }

        public string TagFilter { get; set; }

        public bool IncludeArchive { get; set; }

        public bool IncludeSolvedShots { get; set; }
    }
}