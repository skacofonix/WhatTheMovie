namespace WTM.Crawler.Domain
{
    public sealed class SnapshotDifficultyChoiceEasy : SnapshotDifficultyChoice
    {
        public override SnapshotDifficulty Difficulty
        {
            get { return SnapshotDifficulty.Easy; }
        }

        public override string ToString()
        {
            return "easy";
        }
    }
}