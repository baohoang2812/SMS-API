using AutoMapper;
using StudentManagement.Data.ViewModels;

namespace StudentManagement.Data.Mappings
{
    public class StudentMappingProfile : Profile
    {
        public StudentMappingProfile()
        {
            CreateMap<StudentCreateViewModel, Student>();
            CreateMap<StudentUpdateViewModel, Student>();
        }
    }
}
