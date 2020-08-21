using Microsoft.EntityFrameworkCore;

namespace StudentManagement.Data.Repository
{
    public interface IStudentRepository : IBaseRepository<Student, int>
    {

    }
    public class StudentRepository : BaseRepository<Student, int>, IStudentRepository
    {
        public StudentRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
