using OnlineEducation.Data;
using OnlineEducation.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducation.DataAccess.Concrete
{
   public class UnitOfWork : IUnitOfWork
    {
        private readonly OnlineEducationContext _context;
        public IEducationProgramRepository EducationPrograms { get; }
        public ISubProgramRepository SubPrograms { get; }

        public UnitOfWork(OnlineEducationContext onlineEducationContext,
            IEducationProgramRepository educationProgramRepository,
            ISubProgramRepository subProgramRepository)
        {
            this._context = onlineEducationContext;
            this.EducationPrograms = educationProgramRepository;
            this.SubPrograms = subProgramRepository;
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
