using StudentClassroomCaseStudy.Data;
using StudentClassroomCaseStudy.Interface;
using StudentClassroomCaseStudy.Model;

namespace StudentClassroomCaseStudy.Repository
{
    public class AllocateClassroomRepository : IAllocateClassroomRepository
    {
        private readonly DataContext _dataContext;
        public AllocateClassroomRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public bool AllocateClassroom(int TeacherId, int ClassroomId)
        {
            var teacher = _dataContext.Teachers.SingleOrDefault(t => t.TeacherId == TeacherId);
            var classroom = _dataContext.Classrooms.SingleOrDefault(c => c.ClassroomId == ClassroomId);

            if (teacher != null && classroom != null)
            {
                var allocateClassroom = new AllocateClassroom
                {
                    TeacherId = TeacherId,
                    ClassroomId = ClassroomId
                };

                _dataContext.AllocateClassrooms.Add(allocateClassroom);
                _dataContext.SaveChanges();
                return true;
            }
            else
            {
                
                throw new InvalidOperationException("Teacher or Classroom not found.");
            }
        }

        public bool DeleteAllocatedClassroom(int allocatedClassroomId)
        {
            var allocatedClassroom = GetClassroom(allocatedClassroomId);

            if (allocatedClassroom != null)
            {
                _dataContext.AllocateClassrooms.Remove(allocatedClassroom);
                _dataContext.SaveChanges();
                return true;
            }

            return false;
        }

        public ICollection<AllocateClassroom> GetAllocatedClassrooms()
        {
            return _dataContext.AllocateClassrooms.OrderBy(p => p.ClassroomId).ToList();
        }

        public AllocateClassroom GetClassroom(int id)
        {
            return _dataContext.AllocateClassrooms.Where(x => x.ClassroomId == id).FirstOrDefault();
        }



    }
}
