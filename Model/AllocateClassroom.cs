namespace StudentClassroomCaseStudy.Model
{
    public class AllocateClassroom
    {
        public int AllocateClassroomId { get; set; }
        public int TeacherId { get; set; }
        public int ClassroomId { get; set; }
        public Teacher Teacher { get; set; }
        public Classroom Classroom { get; set; }
    }
}
