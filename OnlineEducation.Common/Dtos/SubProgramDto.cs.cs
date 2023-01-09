using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducation.Common.Dtos
{
    public class SubProgramDto : BaseDto
    {
        public int EducationProgramId { get; set; }
        public string Name { get; set; }
        public string Explanation { get; set; }
        public string Link { get; set; }
    }
}
