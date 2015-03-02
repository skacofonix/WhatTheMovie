using System.Collections.Generic;
using WTM.Domain;

namespace WTM.Core.Services
{
    public interface IUserService
    {
        User GetUser(string username);

        IEnumerable<UserSummary> Search(string username, int? page = null);
    }
}