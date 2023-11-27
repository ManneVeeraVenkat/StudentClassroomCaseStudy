using StudentClassroomCaseStudy.Model;


namespace TeacherClassroomCaseStudy.Interface
{
    public interface ITeacherRepository
    {
        ICollection<Teacher> GetTeachers();
        Teacher GetTeacher(int id);
        bool CreateTeacher(Teacher Teacher);
        bool UpdateTeacher(Teacher Teacher);
        bool DeleteTeacher(Teacher Teacher);
        bool Save();
    }
}
