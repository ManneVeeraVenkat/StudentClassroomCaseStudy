using StudentClassroomCaseStudy.Data;
using StudentClassroomCaseStudy.Model;

namespace StudentClassroomCaseStudy.Interface
{
    public interface IAllocateClassroomRepository
    {
        bool AllocateClassroom(int TeacherId, int ClassroomId);
        bool DeleteAllocatedClassroom(int allocatedClassroomId);
        ICollection<AllocateClassroom> GetAllocatedClassrooms();
        public AllocateClassroom GetClassroom(int id);
      
    }
}
