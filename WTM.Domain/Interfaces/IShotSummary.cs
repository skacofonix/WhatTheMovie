namespace WTM.Domain.Interfaces
{
    public interface IShotSummary : IWebsiteEntity
    {
        int ShotId { get; set; }

        string ImageUrl { get; set; }

        ShotUserStatus UserStatus { get; set; }
    }
}