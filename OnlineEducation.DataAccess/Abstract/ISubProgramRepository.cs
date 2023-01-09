using OnlineEducation.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducation.DataAccess.Abstract
{
    public interface ISubProgramRepository : IGenericRepository<SubProgram>
    {
        Task<IEnumerable<SubProgram>> GetSubProgramListByEducationProgramId(int educationprogramId);
    }
}
