using System;

namespace WTM.RestApi.Models
{
    public interface IUserSearchSummary
    {
        string Username { get; }
        string Rank { get; }
        Uri Avatar { get; }
    }
}