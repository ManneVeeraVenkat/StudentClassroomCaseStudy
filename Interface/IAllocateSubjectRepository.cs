using StudentClassroomCaseStudy.Model;

namespace StudentClassroomCaseStudy.Interface
{
    public interface IAllocateSubjectRepository
    {
        bool AllocateSubject(int TeacherId, int SubjectId);
        bool DeleteAllocatedSubject(int allocatedSubjectId);
        ICollection<AllocateSubject> GetAllocatedSubjects();
        public AllocateSubject GetSubject(int AllocatedSubjectId);
    }
}
