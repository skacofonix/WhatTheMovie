namespace WTM.Domain.Interfaces
{
    public interface IRate
    {
        decimal Score { get; }

        int NbRaters { get; }
    }
}