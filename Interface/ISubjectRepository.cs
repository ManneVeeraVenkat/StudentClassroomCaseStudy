using StudentClassroomCaseStudy.Model;


namespace SubjectClassroomCaseStudy.Interface
{
    public interface ISubjectRepository
    {
        ICollection<Subject> GetSubjects();
        Subject GetSubject(int id);
        bool CreateSubject(Subject Subject);
        bool UpdateSubject(Subject Subject);
        bool DeleteSubject(Subject Subject);
        bool Save();
    }
}
