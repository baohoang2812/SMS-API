using StudentManagement.Data.Repository;
using System.Collections.Generic;

namespace StudentManagement.Data.Services
{
    public interface IClassService : IBaseService<Class, int>
    {
        List<Class> GetClassList(int[] ids, string name, int capacity, int pageIndex);
    }
    public class ClassService : BaseService<Class, int>, IClassService
    {
        private IClassRepository classRepository;
        public ClassService(IUnitOfWork unitOfWork, IClassRepository classRepository) : base(unitOfWork, classRepository)
        {
            this.classRepository = classRepository;
        }

        public List<Class> GetClassList(int[] ids, string name, int capacity, int index)
        {
            return classRepository.GetClassList(ids, name, capacity, index);
        }
    }
}
