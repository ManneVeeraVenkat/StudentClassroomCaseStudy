using StudentClassroomCaseStudy.Model;

namespace StudentClassroomCaseStudy.Dto
{
    public class TeacherDto
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ContactNo { get; set; }
        public string EmailAdress { get; set; }
        public ICollection<AllocateSubjectDto> AllocateSubjects { get; set; }
        public ICollection<AllocateClassroom> AllocateClassrooms { get; set; }
    }
}
