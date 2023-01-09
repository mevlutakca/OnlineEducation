using Microsoft.EntityFrameworkCore;
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
    public class SubProgramRepository : GenericRepository<SubProgram>, ISubProgramRepository
    {
        protected readonly OnlineEducationContext _context;
        public SubProgramRepository(OnlineEducationContext context) : base(context)
        {
            _context = context;
        }
       public async Task<IEnumerable<SubProgram>> GetSubProgramListByEducationProgramId(int educationprogramId)
        {
            return await _context.SubPrograms.Where(x => x.EducationProgramId == educationprogramId).ToListAsync();
        }
    }
}
