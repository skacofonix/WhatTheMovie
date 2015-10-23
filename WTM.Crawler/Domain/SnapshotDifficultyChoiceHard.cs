namespace WTM.Crawler.Domain
{
    public sealed class SnapshotDifficultyChoiceHard : SnapshotDifficultyChoice
    {
        public override SnapshotDifficulty Difficulty
        {
            get { return SnapshotDifficulty.Hard; }
        }

        public override string ToString()
        {
            return "hard";
        }
    }
}