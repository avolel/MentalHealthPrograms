using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Models;
using DataAccess;

namespace MentalHealthPrograms.Controllers
{
    public class MentalHealthController : ApiController
    {
        public IEnumerable<MentalHealthProgram> GetMentalHealthPrograms()
        {
            return MentalHealthProgramsDataAccess.GetMentalHealthPrograms();
        }

        public IEnumerable<MentalHealthProgram> GetMentalHealthPrograms(string name)
        {
            return MentalHealthProgramsDataAccess.GetMentalHealthPrograms(name);
        }
    }
}
