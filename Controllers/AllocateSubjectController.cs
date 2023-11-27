using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentClassroomCaseStudy.Data;
using StudentClassroomCaseStudy.Dto;
using StudentClassroomCaseStudy.Interface;

namespace StudentClassroomCaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllocateSubjectController : ControllerBase
    {
        private readonly IAllocateSubjectRepository _IAllocateSubjectRepository;
      
        private readonly IMapper _mapper;
        public AllocateSubjectController(IAllocateSubjectRepository IAllocateSubjectRepository, IMapper mapper)
        {

            _IAllocateSubjectRepository = IAllocateSubjectRepository;
            _mapper = mapper;

        }
        [HttpPost]
        public IActionResult AllocateSubject([FromBody] AllocateSubjectDto allocation)
        {
            if (allocation == null)
            {
                return BadRequest("Invalid allocation data.");
            }

            try
            {
                if (_IAllocateSubjectRepository.AllocateSubject(allocation.TeacherId, allocation.SubjectId))
                {
                    return Ok("Allocation successful");
                }
                else
                {
                    return BadRequest("Failed to allocate subject.");
                }
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest($"Allocation failed: {ex.Message}");
            }
        }
        [HttpDelete]
        public IActionResult DeletedSubject(int AllocationId)
        {
          
            var allocatedSubject = _IAllocateSubjectRepository.GetSubject(AllocationId);
            if (allocatedSubject == null)
            {
                return NotFound(); // Student not found, return 404 (Not Found).
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
            }
            try
            {
                if (_IAllocateSubjectRepository.DeleteAllocatedSubject(AllocationId))
                {
                    return NoContent(); // Student deleted successfully, return 204 (No Content).
                }
                else
                {
                    ModelState.AddModelError("", "Something went wrong while deleting the student");
                    return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                }
            }
            catch (Exception ex)
            {


                ModelState.AddModelError("", "An error occurred while deleting the student.");
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
            }

        }
        [HttpGet]
        public IActionResult GetAllocatedSubjects()
        {
            var Students = _mapper.Map<List<AllocateSubjectDto>>(_IAllocateSubjectRepository.GetAllocatedSubjects().ToList());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
            }
            return Ok(Students);
        }
    
}
}
