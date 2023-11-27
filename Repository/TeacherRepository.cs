
using Microsoft.EntityFrameworkCore;
using StudentClassroomCaseStudy.Data;
using StudentClassroomCaseStudy.Model;
using TeacherClassroomCaseStudy.Interface;

namespace StudentClassroomCaseStudy.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly DataContext _dataContext;
        public TeacherRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public bool CreateTeacher(Teacher Teacher)
        {
            _dataContext.Add(Teacher);
            _dataContext.SaveChanges();
            return true;
        }

        public bool DeleteTeacher(Teacher Teacher)
        {

            _dataContext.Teachers.Remove(Teacher);
            _dataContext.SaveChanges();
            return true;
        }

        public Teacher GetTeacher(int id)
        {
            return _dataContext.Teachers
                .Include(s=>s.AllocateClassrooms)
                .Include(C=>C.AllocateSubjects)
                .Where(x => x.TeacherId == id).FirstOrDefault();
        }

        public ICollection<Teacher> GetTeachers()
        {
            return _dataContext.Teachers
                 .Include(teacher => teacher.AllocateClassrooms) // Include AllocateClassrooms
                 .Include(teacher => teacher.AllocateSubjects) // Include AllocateSubjects
                 .OrderBy(teacher => teacher.TeacherId) // Order by TeacherId
                 .ToList();

        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateTeacher(Teacher Teacher)
        {
            throw new NotImplementedException();
        }
    }
}
