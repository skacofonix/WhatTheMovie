using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTM.Domain;

namespace WTM.WebsiteClient.Application
{
    public class DifficultyOptions
    {
        public SnapshotDifficulty SnapshotDifficultyFilter { get; set; }

        public string TagFilter { get; set; }

        public bool IncludeArchive { get; set; }

        public bool IncludeSolvedShots { get; set; }
    }
}