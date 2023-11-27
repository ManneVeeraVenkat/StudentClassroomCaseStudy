using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentClassroomCaseStudy.Data;
using StudentClassroomCaseStudy.Dto;
using StudentClassroomCaseStudy.Interface;
using StudentClassroomCaseStudy.Repository;
using TeacherClassroomCaseStudy.Interface;

namespace StudentClassroomCaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllocateClassroomController : ControllerBase
    {
        private readonly IAllocateClassroomRepository _IAllocateclassroomRepository;
        private readonly DataContext dataContext;
        private readonly IMapper _mapper;
        public AllocateClassroomController(IAllocateClassroomRepository IAllocateclassroomRepository, IMapper mapper)
        {

           _IAllocateclassroomRepository = IAllocateclassroomRepository;
            _mapper = mapper;

        }
        [HttpPost]
        public IActionResult AllocateClassroom([FromBody] AllocateClassroomDto allocation)
        {
            if (allocation == null)
            {
                return BadRequest("Invalid allocation data.");
            }

            try
            {
                if (_IAllocateclassroomRepository.AllocateClassroom(allocation.TeacherId, allocation.ClassroomId))
                {
                    return Ok("Allocation successful");
                }
                else
                {
                    return BadRequest("Failed to allocate classroom.");
                }
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest($"Allocation failed: {ex.Message}");
            }
        }
        [HttpDelete]
        public IActionResult DeletedClassroom(int AllocationId)
        {
            Console.WriteLine($"AllocationId: {AllocationId}");
            var allocatedClassRoom = _IAllocateclassroomRepository.GetClassroom(AllocationId);
            if (allocatedClassRoom == null)
            {
                return NotFound(); // Student not found, return 404 (Not Found).
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
            }
            try
            {
                if (_IAllocateclassroomRepository.DeleteAllocatedClassroom(AllocationId))
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
        public IActionResult GetClassrooms()
        {
            var Students = _mapper.Map<List<AllocateClassroomDto>>(_IAllocateclassroomRepository.GetAllocatedClassrooms().ToList());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
            }
            return Ok(Students);
        }
    }
}
