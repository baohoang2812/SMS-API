using StudentManagement.Data.Repository;

namespace StudentManagement.Data.Services
{
    public interface IStudentService : IBaseService<Student, int>
    {

    }
    public class StudentService : BaseService<Student, int>, IStudentService
    {
        public StudentService(IUnitOfWork unitOfWork, IStudentRepository studentRepository) : base(unitOfWork, studentRepository)
        {
        }
    }
}
