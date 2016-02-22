using System;

namespace WTM.Api.Models
{
    public interface IUserSummary
    {
        string Username { get; }
        string Rank { get; }
        Uri AvatarUrl { get; }
        Uri ProfilUrl { get; }
    }
}