namespace WTM.Crawler.Domain
{
    public sealed class SnapshotDifficultyChoiceEasyMedium : SnapshotDifficultyChoice
    {
        public override SnapshotDifficulty Difficulty
        {
            get { return SnapshotDifficulty.Easy | SnapshotDifficulty.Medium; }
        }

        public override string ToString()
        {
            return "medium";
        }
    }
}