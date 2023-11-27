namespace StudentClassroomCaseStudy.Model
{
    public class AllocateSubject
    {
        public int AllocateSubjectId { get; set; }
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }

        public Teacher Teacher { get; set; }
        public Subject Subject { get; set; }
    }
}
