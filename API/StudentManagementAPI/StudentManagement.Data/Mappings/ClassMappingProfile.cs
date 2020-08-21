using AutoMapper;
using StudentManagement.Data.ViewModels;

namespace StudentManagement.Data.Mappings
{
    public class ClassMappingProfile : Profile
    {
        public ClassMappingProfile()
        {
            CreateMap<ClassCreateViewModel, Class>();
            CreateMap<ClassUpdateViewModel, Class>();
        }
    }
}
