using System;

namespace WTM.Domain.Interfaces
{
    public interface IUserSummary : IWebsiteEntity
    {
        string Username { get; set; }
        
        string Rank { get; set; }
        
        string Status { get; set; }

        string Country { get; set; }
        
        Uri Avatar { get; set; }
    }
}