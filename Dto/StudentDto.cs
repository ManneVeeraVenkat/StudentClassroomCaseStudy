using StudentClassroomCaseStudy.Model;

namespace StudentClassroomCaseStudy.Dto
{
    public class StudentDto
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactPerson { get; set; }
        public int ContactNo { get; set; }
        public string EmailAdress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
  
        //public ClassroomDto Classroom { get; set; }
      

    }
}
