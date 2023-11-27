namespace StudentClassroomCaseStudy.Model
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }

        public ICollection<AllocateSubject> AllocateSubjects { get; set; }
    }
}
