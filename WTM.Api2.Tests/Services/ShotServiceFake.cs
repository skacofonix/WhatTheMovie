using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTM.Api2.Models;
using WTM.Api2.Models.Response;
using WTM.Api2.Services;

namespace WTM.Api2.Tests.Services
{
    public class ShotServiceFake : IShotService
    {
        public ShotResponse GetById(Int32 id, String token)
        {
            throw new NotImplementedException();
        }

        public ShotResponse GetRandom(String token)
        {
            throw new NotImplementedException();
        }

        public ShotGuessSolutionResponse GuessSolution(Int32 id, String title, String token)
        {
            throw new NotImplementedException();
        }

        public ShotSolutionResponse GetSolution(Int32 id, String token)
        {
            throw new NotImplementedException();
        }
    }
}
