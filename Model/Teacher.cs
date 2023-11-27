namespace StudentClassroomCaseStudy.Model
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ContactNo { get; set; }
        public string EmailAdress { get; set; }
        public ICollection<AllocateSubject> AllocateSubjects { get; set; }
        public ICollection<AllocateClassroom> AllocateClassrooms { get; set; }

    }
}
