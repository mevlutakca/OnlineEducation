using OnlineEducation.Data;
using OnlineEducation.Data.Entity;
using OnlineEducation.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducation.DataAccess.Concrete
{
    public class EducationProgramRepository : GenericRepository<EducationProgram>, IEducationProgramRepository
    {
        public EducationProgramRepository(OnlineEducationContext context) : base(context)
        {

        }
    }
}
