using AutoMapper;
using Final_Version_Of_School_Management_System.DTOs.TeacherDTOs;
using Final_Version_Of_School_Management_System.Models;

namespace Final_Version_Of_School_Management_System.Mappings.TeacherMapping
{
    public class TeacherProfile: Profile
    {
        public TeacherProfile()
        {
            CreateMap<Teacher, GetAllTeachers>()
     .ForMember(m => m.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
     .ForMember(m => m.DepartmentName, opt => opt.MapFrom(src => src.Department.Name));

            CreateMap<CreateTeacherDto, Teacher>()
                               .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FullName.Split(new[] { ' ' })[0]))
                               .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.FullName.Split(new[] { ' ' })[1]));
        }
    }
}
