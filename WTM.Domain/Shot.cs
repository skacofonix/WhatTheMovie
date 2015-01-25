using System;
using System.Collections.Generic;

namespace WTM.Domain
{
    public class Shot : BaseClass
    {
        public User PostedBy { get; set; }
        
        public User FirstSolvedBy { get; set; }
        
        public DateTime PublidationDate { get; set; }
        
        public SnapshotDifficulty Difficulty { get; set; }
        
        public bool IsGore { get; set; }
        
        public bool IsNudity { get; set; }
        
        public List<Tag> Tags { get; set; }
        
        public Movie Movie { get; set; }

        public int DayRemainingBeforeSolution { get; set; }

        public DateTime DateSolution { get; set; }
    }
}
