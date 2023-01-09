using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEducation.Common.Dtos;
using OnlineEducation.Data.Entity;
using OnlineEducation.DataAccess.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineEducation.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class SubProgramController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public SubProgramController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost(nameof(AddSubProgram))]
        public IActionResult AddSubProgram(SubProgramDto subProgram)
        {
            var entity = new SubProgram()
            {
                Name = subProgram.Name,
                EducationProgramId = subProgram.EducationProgramId,
                Explanation = subProgram.Explanation,
                Link = subProgram.Link
            };
            var result = _unitOfWork.SubPrograms.Add(entity);
            _unitOfWork.Complete();
            if (result is not null) return Ok("Sub program added");
            else return BadRequest("Error in adding the sub program");
        }

        [HttpPut(nameof(UpdateSubProgram))]
        public IActionResult UpdateSubProgram(SubProgramDto subProgram)
        {
            var entity = new SubProgram()
            {
                Id = subProgram.Id,
                Name = subProgram.Name,
                EducationProgramId = subProgram.EducationProgramId,
                Explanation = subProgram.Explanation,
                Link = subProgram.Link
            };
            _unitOfWork.SubPrograms.Update(entity);
            _unitOfWork.Complete();
            return Ok("Sub program updated");
        }

        [HttpGet(nameof(GetSubPrograms))]
        public async Task<IEnumerable<SubProgram>> GetSubPrograms()
        {
            return await _unitOfWork.SubPrograms.GetAll();
        }

        [HttpGet(nameof(GetSubProgramListByEducationProgramId))]
        public async Task<IEnumerable<SubProgram>> GetSubProgramListByEducationProgramId(int educationprogramId)
        {
            return await _unitOfWork.SubPrograms.GetSubProgramListByEducationProgramId(educationprogramId);
        }

        [HttpGet(nameof(GetSubProgramById))]
        public async Task<SubProgram> GetSubProgramById(int id)
        {
            return await _unitOfWork.SubPrograms.Get(id);
        }

        [HttpPost(nameof(DeleteSubProgram))]
        public IActionResult DeleteSubProgram(SubProgramDto subProgram)
        {
            var entity = new SubProgram()
            {
                Id = subProgram.Id
            };
            _unitOfWork.SubPrograms.Delete(entity);
            _unitOfWork.Complete();
            return Ok("Sub program deleted");
        }

    }
}
