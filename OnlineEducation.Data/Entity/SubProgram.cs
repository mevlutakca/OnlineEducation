using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlineEducation.Data.Entity
{
    public class SubProgram : BaseEntity
    {
        [Required]
        [ForeignKey("EducationProgram")]
        public int EducationProgramId { get; set; }
        public string Name { get; set; }
        public string Explanation { get; set; }
        public string Link { get; set; }
        public virtual EducationProgram EducationProgram { get; set; }
    }
}
