using StudentManagement.Data.Repository;

namespace StudentManagement.Data.Services
{
    public interface IClassService: IBaseService<Class, int>
    {

    }
    public class ClassService : BaseService<Class, int>, IClassService
    {
        public ClassService(IUnitOfWork unitOfWork, IClassRepository classRepository) : base(unitOfWork, classRepository)
        {
        }
    }
}
