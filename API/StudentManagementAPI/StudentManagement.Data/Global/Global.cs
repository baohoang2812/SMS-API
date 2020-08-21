using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using StudentManagement.Data.Mappings;

namespace StudentManagement.Data.Global
{
    public static class Global
    {
        public static IMapper Mapper { get; private set; }
        public static void ConfigureMapper(IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<StudentMappingProfile>();
                c.AddProfile<ClassMappingProfile>();
            });
            IMapper mapper = mapperConfig.CreateMapper();
            Mapper = mapper;
        }
    }
}
