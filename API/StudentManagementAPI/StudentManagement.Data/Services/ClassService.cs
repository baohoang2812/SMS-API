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
        private IClassRepository _classRepository;
        private IStudentRepository _studentRepository;
        public ClassService(IUnitOfWork unitOfWork, IClassRepository classRepository, IStudentRepository studentRepository) : base(unitOfWork, classRepository)
        {
            this._classRepository = classRepository;
            this._studentRepository = studentRepository;
        }

        public List<Class> GetClassList(int[] ids, string name, int capacity, int index)
        {
            return _classRepository.GetClassList(ids, name, capacity, index);
        }
        public override Class Remove(int id)
        {
            var classStudents = _studentRepository.GetStudentByClass(id);
            classStudents.ForEach(s =>
            {
                s.ClassId = null;
            });
            return base.Remove(id);
        }
    }
}
