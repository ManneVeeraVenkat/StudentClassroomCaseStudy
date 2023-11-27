using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentClassroomCaseStudy.Dto;
using StudentClassroomCaseStudy.Model;
using TeacherClassroomCaseStudy.Interface;

namespace StudentTeacherCaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepository _ITeacherRepository;
        private readonly IMapper _mapper;
        public TeacherController( ITeacherRepository ITeacherRepository, IMapper mapper)
        {

            _ITeacherRepository = ITeacherRepository;
            _mapper = mapper;

        }
        [HttpGet]
        public IActionResult GetTeachers()
        {
            var Students = _mapper.Map<List<TeacherDto>>(_ITeacherRepository.GetTeachers().ToList());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
            }
            return Ok(Students);
        }
        [HttpGet("TeacherId")]
        public IActionResult GetTeacher(int id)
        {
            var Student = _mapper.Map<TeacherDto>(_ITeacherRepository.GetTeacher(id));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
            }
            return Ok(Student);
        }
        [HttpDelete("TeacherId")]

        public IActionResult Delete(int id)
        {
            var teacherToDelete = _ITeacherRepository.GetTeacher(id);

            if (teacherToDelete == null)
            {
                return NotFound(); // Student not found, return 404 (Not Found).
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
            }

            try
            {
                if (_ITeacherRepository.DeleteTeacher(teacherToDelete))
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
        public IActionResult CreateStudent([FromBody] TeacherDto TeacherToCreate)
        {
            if (TeacherToCreate == null)
            {
                return BadRequest();
            }
            var student = _ITeacherRepository.GetTeachers()
                .Where(c => c.FirstName.Trim().ToUpper() == TeacherToCreate.FirstName.TrimEnd().ToUpper()).FirstOrDefault();
            if (student != null)
            {
                ModelState.AddModelError("", "Student already exists");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var TeacherMap = _mapper.Map<Teacher>(TeacherToCreate);



            if (!_ITeacherRepository.CreateTeacher(TeacherMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");

        }
    }
}
