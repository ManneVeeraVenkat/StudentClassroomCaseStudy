using StudentClassroomCaseStudy.Data;
using StudentClassroomCaseStudy.Interface;
using StudentClassroomCaseStudy.Model;

namespace StudentClassroomCaseStudy.Repository
{
    public class ClassroomRepository : IClassroomRepository
    {
        private readonly DataContext _dataContext;
        public ClassroomRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public bool CreateClassroom(Classroom classroom)
        {
            _dataContext.Add(classroom);
            _dataContext.SaveChanges();
            return true;
        }

       

        public bool DeleteClassroom(Classroom classroom)
        {
            _dataContext.Classrooms.Remove(classroom);
            _dataContext.SaveChanges();
            return true;
        }

       

        public Classroom GetClassroom(int id)
        {
            return _dataContext.Classrooms.Where(x => x.ClassroomId == id).FirstOrDefault();
        }

        public ICollection<Classroom> GetClassrooms()
        {
            return _dataContext.Classrooms.OrderBy(p => p.ClassroomId).ToList();
        }

     

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateClassroom(int ownerId, int categoryId, Classroom classroom)
        {
            throw new NotImplementedException();
        }

      
    }
}
