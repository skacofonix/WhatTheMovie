namespace WTM.Domain
{
    public interface IRate
    {
        decimal Score { get; }

        int NbRaters { get; }
    }
}