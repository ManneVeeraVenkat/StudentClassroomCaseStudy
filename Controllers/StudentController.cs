using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentClassroomCaseStudy.Dto;
using StudentClassroomCaseStudy.Interface;
using StudentClassroomCaseStudy.Model;

namespace StudentClassroomCaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _IstudentRepository;
        private readonly IClassroomRepository _IclassroomRepository;
        private readonly IMapper _mapper;
        public StudentController(IStudentRepository IstudentRepository,IClassroomRepository IclassroomRepository,IMapper mapper) { 
            _IstudentRepository = IstudentRepository;
            _IclassroomRepository = IclassroomRepository;
            _mapper = mapper;

        }
        [HttpGet]
        public IActionResult GetStudents() { 
            var Students=_mapper.Map<List<Student>>(_IstudentRepository.GetStudents().ToList());
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
            }
            return Ok(Students);
        }
        [HttpGet("StudentId")]
        public IActionResult GetStudent(int id)
        {
            var Student=_mapper.Map<Student>(_IstudentRepository.GetStudent(id));
            if(!ModelState.IsValid) {
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
            }
            return Ok(Student);
        }
        [HttpDelete("StudentId")]
     
        public IActionResult Delete(int id)
        {
            var studentToDelete = _IstudentRepository.GetStudent(id);

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
                if (_IstudentRepository.DeleteStudent(studentToDelete))
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
        public IActionResult CreateStudent([FromQuery]int classroomId,[FromBody] StudentDto studentTocreate)
        {
            if(studentTocreate == null)
            {
                return BadRequest();
            }
            var student = _IstudentRepository.GetStudents()
                .Where(c => c.LastName.Trim().ToUpper() == studentTocreate.LastName.TrimEnd().ToUpper()).FirstOrDefault();
            if (student != null)
            {
                ModelState.AddModelError("", "Student already exists");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var studentMap=_mapper.Map<Student>(studentTocreate);

            studentMap.Classroom = _IclassroomRepository.GetClassroom(classroomId);

            if (!_IstudentRepository.CreateStudent(studentMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");

        }
        //[HttpPut]
        //public IActionResult UpdateStudent(int studentId, StudentDto studentxToUpdate)
        //{
        //    if (studentxToUpdate == null)
        //    {
        //        return BadRequest("Invalid input. Provide a valid student object for update.");
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var studentMap = _mapper.Map<Student>(studentxToUpdate);

        //    try
        //    {
        //        if (_IstudentRepository.UpdateStudent(studentMap))
        //        {
        //            // Return the updated student object.
        //            return Ok(studentMap);
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Something went wrong while saving.");
        //            return StatusCode(500, ModelState);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception for debugging purposes and return an appropriate error response.
        //        ModelState.AddModelError("", "An error occurred while updating the student.");
        //        return StatusCode(500, ModelState);
        //    }
        //}



    }
}
