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
    public class EducationProgramController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public EducationProgramController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost(nameof(AddEducationProgram))]
        public IActionResult AddEducationProgram(EducationProgramDto educationProgram)
        {
            var entity = new EducationProgram()
            {
                Name = educationProgram.Name,
                StartDate = System.DateTime.Now,
                EndDate = System.DateTime.Now,
                Status = 0
            };
            var result = _unitOfWork.EducationPrograms.Add(entity);
            _unitOfWork.Complete();
            if (result is not null) return Ok("Education program added");
            else return BadRequest("Error in adding the education program");
        }

        [HttpPut(nameof(UpdateEducationProgram))]
        public IActionResult UpdateEducationProgram(EducationProgramDto educationProgram)
        {
            var entity = new EducationProgram()
            {
                Id=educationProgram.Id,
                Name = educationProgram.Name,
                StartDate = System.DateTime.Now,
                EndDate = System.DateTime.Now,
                Status = 0
            };
            _unitOfWork.EducationPrograms.Update(entity);
            _unitOfWork.Complete();
            return Ok("Education program updated");
        }

        [HttpGet(nameof(GetEducationPrograms))]
        public async Task<IEnumerable<EducationProgram>> GetEducationPrograms()
        {
            return await _unitOfWork.EducationPrograms.GetAll();
        }

        [HttpGet(nameof(GetEducationProgramById))]
        public async Task<EducationProgram> GetEducationProgramById(int id)
        {
            return await _unitOfWork.EducationPrograms.Get(id);
        }

        [HttpPost(nameof(DeleteEducationProgram))]
        public IActionResult DeleteEducationProgram(EducationProgramDto educationProgram)
        {
            var entity = new EducationProgram()
            {
               Id=educationProgram.Id
            };
            _unitOfWork.EducationPrograms.Delete(entity);
            _unitOfWork.Complete();
            return Ok("Education program deleted");
        }

    }
}
