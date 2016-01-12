using System;

namespace WTM.RestApi.Models
{
    public interface IUserSummary
    {
        string Username { get; }
        string Rank { get; }
        Uri AvatarUrl { get; }
        Uri ProfilUrl { get; }
    }
}