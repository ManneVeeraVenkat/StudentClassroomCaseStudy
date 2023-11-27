using AutoMapper;
using StudentClassroomCaseStudy.Dto;
using StudentClassroomCaseStudy.Model;

namespace StudentClassroomCaseStudy.Heleper
{
    public class AutoMapper:Profile
    {
        public AutoMapper()
        {
            CreateMap<Student,StudentDto>();
            CreateMap<StudentDto,Student>();
            CreateMap<Classroom,ClassroomDto>();
            CreateMap<ClassroomDto, Classroom>();
            CreateMap<Teacher, TeacherDto>();
            CreateMap<TeacherDto, Teacher>();
            CreateMap<Subject, SubjectDto>();
            CreateMap<SubjectDto, Subject>();
            CreateMap<AllocateClassroom, AllocateClassroomDto>();
            CreateMap<AllocateClassroomDto, AllocateClassroom>();
            CreateMap<AllocateSubject, AllocateSubjectDto>();
            CreateMap<AllocateSubjectDto, AllocateSubject>();
        }
    }
}
