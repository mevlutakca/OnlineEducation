using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducation.DataAccess.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IEducationProgramRepository EducationPrograms { get; }
        ISubProgramRepository SubPrograms { get; }
        int Complete();
    }
}
