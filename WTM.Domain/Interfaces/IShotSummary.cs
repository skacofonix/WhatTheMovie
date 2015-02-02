namespace WTM.Domain
{
    public interface IShotSummary
    {
        int ShotId { get; set; }

        string ImageUrl { get; set; }

        ShotUserStatus UserStatus { get; set; }
    }
}