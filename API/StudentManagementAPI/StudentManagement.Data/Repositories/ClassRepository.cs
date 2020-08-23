using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagement.Data.Repository
{
    public interface IClassRepository : IBaseRepository<Class, int>
    {
        List<Class> GetClassList(string name, int capacity, int index);
    }
    public class ClassRepository : BaseRepository<Class, int>, IClassRepository
    {
        private readonly SMSContext context;
        public ClassRepository(SMSContext dbContext) : base(dbContext)
        {
            context = dbContext;
        }

        public List<Class> GetClassList(string name, int capacity, int index)
        {
            var listClass = context.Class.Where(s => s.Name.ToLower()
            .Contains(name.ToLower())).Skip((index - 1) * capacity)
            .Take(capacity).ToList();
            return listClass;
        }
    }
}
