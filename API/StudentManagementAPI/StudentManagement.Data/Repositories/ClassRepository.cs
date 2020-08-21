using Microsoft.EntityFrameworkCore;

namespace StudentManagement.Data.Repository
{
    public interface IClassRepository : IBaseRepository<Class, int>
    {

    }
    public class ClassRepository : BaseRepository<Class, int>, IClassRepository
    {
        public ClassRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
