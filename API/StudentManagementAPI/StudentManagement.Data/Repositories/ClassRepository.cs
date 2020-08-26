using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagement.Data.Repository
{
    public interface IClassRepository : IBaseRepository<Class, int>
    {
        List<Class> GetClassList(int[] ids, string name, int capacity, int index);
    }
    public class ClassRepository : BaseRepository<Class, int>, IClassRepository
    {
        private readonly SMSContext context;
        public ClassRepository(SMSContext dbContext) : base(dbContext)
        {
            context = dbContext;
        }

        public List<Class> GetClassList(int[] ids, string name, int capacity, int index)
        {
            var query = context.Class.AsQueryable();
            if (ids != null && ids.Length > 0)
            {
                query = query.Where(s => ids.Contains(s.Id));
            }
            if (name != null)
            {
                query = query.Where(s => s.Name.ToLower().Contains(name.ToLower()));
            }
            return query.Skip((index - 1) * capacity)
            .Take(capacity).ToList();
        }
    }
}
