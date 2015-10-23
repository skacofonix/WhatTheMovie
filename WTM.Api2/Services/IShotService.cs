using System.Web.UI;
using System.Collections.Generic;
using System.Linq;
using WTM.Api2.Models;
using WTM.Api2.Models.Response;

namespace WTM.Api2.Services
{
    public interface IShotService
    {
        ShotResponse GetById(int id, string token = null);
        ShotResponse GetRandom(string token);
        ShotGuessSolutionResponse GuessSolution(int id, string title, string token = null);
        ShotSolutionResponse GetSolution(int id, string token = null);
    }
}