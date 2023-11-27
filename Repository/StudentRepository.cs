using Microsoft.EntityFrameworkCore;
using StudentClassroomCaseStudy.Data;
using StudentClassroomCaseStudy.Dto;
using StudentClassroomCaseStudy.Interface;
using StudentClassroomCaseStudy.Model;

namespace StudentClassroomCaseStudy.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DataContext _dataContext;
        public StudentRepository(DataContext dataConext)
        {
            _dataContext = dataConext;
        }

        public bool CreateStudent( Student Student)
        {
           _dataContext.Add(Student);
            _dataContext.SaveChanges();
            return true;
        }

        public bool DeleteStudent(Student Student)
        {
            _dataContext.Students.Remove(Student);
            _dataContext.SaveChanges();
            return true;

        }

        public Student GetStudent(int id)
        {
          return _dataContext.Students.Include(C=>C.Classroom).Where(x=>x.StudentId==id).FirstOrDefault();
        }


        public ICollection<Student> GetStudents()
        {
            return _dataContext.Students.Include(C=>C.Classroom).OrderBy(p => p.StudentId).ToList();

        
        }

   
        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateStudent( Student Student)
        {
            try
            {
                _dataContext.Update(Student);
                _dataContext.SaveChanges(); // Save changes to the database.
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes.
                return false;
            }
        }
    }
}
