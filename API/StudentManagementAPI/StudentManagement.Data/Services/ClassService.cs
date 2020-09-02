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
        private readonly IClassRepository _classRepository;
        private readonly IStudentRepository _studentRepository;
        public ClassService(IUnitOfWork unitOfWork, IClassRepository classRepository, IStudentRepository studentRepository) : base(unitOfWork, classRepository)
        {
            this._classRepository = classRepository;
            this._studentRepository = studentRepository;
        }

        public List<Class> GetClassList(int[] ids, string name, int capacity, int pageIndex)
        {
            return _classRepository.GetClassList(ids, name, capacity, pageIndex);
        }
        public override Class Remove(int key)
        {
            var classStudents = _studentRepository.GetStudentByClass(key);
            classStudents.ForEach(s =>
            {
                s.ClassId = null;
            });
            return base.Remove(key);
        }
    }
}
