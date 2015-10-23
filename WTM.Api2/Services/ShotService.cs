using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTM.Api2.Models.Response;

namespace WTM.Api2.Services
{
    public class ShotService : IShotService
    {
        public ShotResponse GetById(int id, string token = null)
        {
            throw new NotImplementedException();
        }

        public ShotResponse GetRandom(string token)
        {
            throw new NotImplementedException();
        }

        public ShotSolutionResponse GetSolution(int id, string token = null)
        {
            throw new NotImplementedException();
        }

        public ShotGuessSolutionResponse GuessSolution(int id, string title, string token = null)
        {
            throw new NotImplementedException();
        }
    }
}
