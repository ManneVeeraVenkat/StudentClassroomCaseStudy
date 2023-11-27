using StudentClassroomCaseStudy.Data;
using StudentClassroomCaseStudy.Interface;
using StudentClassroomCaseStudy.Model;
using SubjectClassroomCaseStudy.Interface;

namespace StudentClassroomCaseStudy.Repository
{
    
    public class SubjectRepository : ISubjectRepository
    {
        private readonly DataContext _dataContext;
        public SubjectRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public bool CreateSubject(Subject Subject)
        {
            _dataContext.Add(Subject);
            _dataContext.SaveChanges();
            return true;
        }

        public bool DeleteSubject(Subject Subject)
        {

            _dataContext.Subjects.Remove(Subject);
            _dataContext.SaveChanges();
            return true;
        }

        public Subject GetSubject(int id)
        {
            return _dataContext.Subjects.Where(x => x.SubjectId == id).FirstOrDefault();
        }

        public ICollection<Subject> GetSubjects()
        {
            return _dataContext.Subjects.OrderBy(p => p.SubjectId).ToList();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateSubject(Subject Subject)
        {
            throw new NotImplementedException();
        }
    }
}
