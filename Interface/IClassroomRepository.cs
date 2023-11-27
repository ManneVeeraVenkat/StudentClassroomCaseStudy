using StudentClassroomCaseStudy.Model;

namespace StudentClassroomCaseStudy.Interface
{
    public interface IClassroomRepository
    {
        ICollection<Classroom> GetClassrooms();
        Classroom GetClassroom(int id);
        bool CreateClassroom(Classroom classroom);
        bool UpdateClassroom(int ownerId, int categoryId, Classroom classroom);
        bool DeleteClassroom(Classroom classroom);
        bool Save();
    }
}
