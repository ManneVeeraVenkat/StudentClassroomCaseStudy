using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentClassroomCaseStudy.Dto;
using StudentClassroomCaseStudy.Interface;
using StudentClassroomCaseStudy.Model;

namespace StudentClassroomCaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomController : ControllerBase
    {
       
        private readonly IClassroomRepository _IclassroomRepository;
        private readonly IMapper _mapper;
        public ClassroomController( IClassroomRepository IclassroomRepository, IMapper mapper)
        {
           
            _IclassroomRepository = IclassroomRepository;
            _mapper = mapper;

        }
        [HttpGet]
        public IActionResult GetClassrooms()
        {
            var Students = _mapper.Map<List<ClassroomDto>>(_IclassroomRepository.GetClassrooms().ToList());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
            }
            return Ok(Students);
        }
        [HttpGet("ClassroomId")]
        public IActionResult GetClassroom(int id)
        {
            var Student = _mapper.Map<ClassroomDto>(_IclassroomRepository.GetClassroom(id));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
            }
            return Ok(Student);
        }
        [HttpDelete("ClassroomId")]

        public IActionResult Delete(int id)
        {
            var studentToDelete = _IclassroomRepository.GetClassroom(id);

            if (studentToDelete == null)
            {
                return NotFound(); // Student not found, return 404 (Not Found).
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
            }

            try
            {
                if (_IclassroomRepository.DeleteClassroom(studentToDelete))
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
        [HttpPost]
        public IActionResult CreateClassroom( [FromBody] ClassroomDto classroomToCreate)
        {
            if (classroomToCreate == null)
            {
                return BadRequest();
            }
            var student = _IclassroomRepository.GetClassrooms()
                .Where(c => c.ClassroomName.Trim().ToUpper() == classroomToCreate.ClassroomName.TrimEnd().ToUpper()).FirstOrDefault();
            if (student != null)
            {
                ModelState.AddModelError("", "Student already exists");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var classroomMap = _mapper.Map<Classroom>(classroomToCreate);

        

            if (!_IclassroomRepository.CreateClassroom(classroomMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");

        }
    }
}
