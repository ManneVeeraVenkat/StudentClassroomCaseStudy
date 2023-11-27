using StudentClassroomCaseStudy.Data;
using StudentClassroomCaseStudy.Interface;
using StudentClassroomCaseStudy.Model;

namespace StudentClassroomCaseStudy.Repository
{
    public class AllocateSubjectRepository : IAllocateSubjectRepository
    {
        private readonly DataContext _dataContext;
        public AllocateSubjectRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public bool AllocateSubject(int TeacherId, int SubjectId)
        {
            var teacher = _dataContext.Teachers.SingleOrDefault(t => t.TeacherId == TeacherId);
            var classroom = _dataContext.Subjects.SingleOrDefault(s=>s.SubjectId == SubjectId);

            if (teacher != null && classroom != null)
            {
                var allocateSubject = new AllocateSubject
                {
                    TeacherId = TeacherId,
                    SubjectId = SubjectId
                };

                _dataContext.AllocateSubjects.Add(allocateSubject);
                _dataContext.SaveChanges();
                return true;
            }
            else
            {

                throw new InvalidOperationException("Teacher or Subject not found.");
            }
        }

        public bool DeleteAllocatedSubject(int allocatedSubjectId)
        {
            var allocatedSubject = GetSubject(allocatedSubjectId);

            if (allocatedSubject != null)
            {
                _dataContext.AllocateSubjects.Remove(allocatedSubject);
                _dataContext.SaveChanges();
                return true;
            }

            return false;
        }

        public ICollection<AllocateSubject> GetAllocatedSubjects()
        {
            return _dataContext.AllocateSubjects.OrderBy(p => p.AllocateSubjectId).ToList();
        }

        public AllocateSubject GetSubject(int AllocatedSubjectid)
        {
            return _dataContext.AllocateSubjects.Where(x => x.AllocateSubjectId == AllocatedSubjectid).FirstOrDefault();
        }
    }
}
