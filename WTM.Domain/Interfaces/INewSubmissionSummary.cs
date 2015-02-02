namespace WTM.Domain.Interfaces
{
    public interface INewSubmissionSummary
    {
        IRate Rate { get; }

        int TimeRemaining { get; }
    }
}
