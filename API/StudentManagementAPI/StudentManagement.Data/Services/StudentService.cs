using StudentManagement.Data.Repository;
using System.Collections.Generic;

namespace StudentManagement.Data.Services
{
    public interface IStudentService : IBaseService<Student, int>
    {
        List<Student> GetStudentList(int[] ids, string name, int capacity, int index, string className);
        Student GetProfile(int id);
    }
    public class StudentService : BaseService<Student, int>, IStudentService
    {
        private IStudentRepository studentRepository;
        public StudentService(IUnitOfWork unitOfWork, IStudentRepository studentRepository) : base(unitOfWork, studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public List<Student> GetStudentList(int[] ids, string name, int capacity, int index, string className)
        {
           return studentRepository.GetStudentList(ids, name, capacity, index, className);
        }

        public Student GetProfile(int id)
        {
            return studentRepository.GetStudentById(id);
        }
    }
}
