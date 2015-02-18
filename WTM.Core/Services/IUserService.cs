using System.Collections.Generic;
using WTM.Domain;
using WTM.Domain.Interfaces;

namespace WTM.Core.Services
{
    public interface IUserService
    {
        IUser GetUser(string username);

        IEnumerable<IUserSummary> Search(string username, int? page = null);
    }
}