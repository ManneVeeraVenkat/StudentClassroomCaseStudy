namespace StudentClassroomCaseStudy.Model
{
    public class Classroom
    {
        public int ClassroomId  { get; set; }
        public string ClassroomName{ get; set; }

        public ICollection<Student> Students { get; set; }
        public ICollection<AllocateClassroom> AllocateClassrooms { get; set; }
    }
}
