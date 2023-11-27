using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentClassroomCaseStudy.Dto;
using StudentClassroomCaseStudy.Model;
using SubjectClassroomCaseStudy.Interface;


namespace SubjectClassroomCaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectRepository _ISubjectRepository;
       
        private readonly IMapper _mapper;
        public SubjectController(ISubjectRepository ISubjectRepository, IMapper mapper)
        {
            _ISubjectRepository = ISubjectRepository;
            
            _mapper = mapper;

        }
        [HttpGet]
        public IActionResult GetSubjects()
        {
            var Subjects = _mapper.Map<List<SubjectDto>>(_ISubjectRepository.GetSubjects().ToList());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
            }
            return Ok(Subjects);
        }
        [HttpGet("SubjectId")]
        public IActionResult GetSubject(int id)
        {
            var Subject = _mapper.Map<SubjectDto>(_ISubjectRepository.GetSubject(id));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
            }
            return Ok(Subject);
        }
        [HttpDelete("SubjectId")]

        public IActionResult Delete(int id)
        {
            var SubjectToDelete = _ISubjectRepository.GetSubject(id);

            if (SubjectToDelete == null)
            {
                return NotFound(); // Subject not found, return 404 (Not Found).
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
            }

            try
            {
                if (_ISubjectRepository.DeleteSubject(SubjectToDelete))
                {
                    return NoContent(); // Subject deleted successfully, return 204 (No Content).
                }
                else
                {
                    ModelState.AddModelError("", "Something went wrong while deleting the Subject");
                    return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                }
            }
            catch (Exception ex)
            {


                ModelState.AddModelError("", "An error occurred while deleting the Subject.");
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
            }
        }
        [HttpPost]
        public IActionResult CreateSubject( [FromBody] SubjectDto SubjectTocreate)
        {
            if (SubjectTocreate == null)
            {
                return BadRequest();
            }
            var Subject = _ISubjectRepository.GetSubjects()
                .Where(c => c.SubjectName.Trim().ToUpper() == SubjectTocreate.SubjectName.TrimEnd().ToUpper()).FirstOrDefault();
            if (Subject != null)
            {
                ModelState.AddModelError("", "Subject already exists");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var SubjectMap = _mapper.Map<Subject>(SubjectTocreate);

            

            if (!_ISubjectRepository.CreateSubject(SubjectMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");

        }
    }
}
