using Microsoft.EntityFrameworkCore;
using OnlineEducation.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineEducation.Data
{
    public class OnlineEducationContext: DbContext
    {
        public OnlineEducationContext(DbContextOptions<OnlineEducationContext> options) : base(options) { }

        public DbSet<EducationProgram> EducationPrograms { get; set; }
        public DbSet<SubProgram> SubPrograms { get; set; }
    }
}
