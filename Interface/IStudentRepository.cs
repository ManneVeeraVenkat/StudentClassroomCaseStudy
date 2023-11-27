using StudentClassroomCaseStudy.Dto;
using StudentClassroomCaseStudy.Model;

namespace StudentClassroomCaseStudy.Interface
{
    public interface IStudentRepository
    {
        ICollection<Student> GetStudents();
        Student GetStudent(int id);
        bool CreateStudent( Student Student);
        bool UpdateStudent( Student Student);
        bool DeleteStudent(Student Student);
        bool Save();
    }
}
