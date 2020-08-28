using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagement.Data.Repository
{
    public interface IStudentRepository : IBaseRepository<Student, int>
    {
        List<Student> GetStudentList(int[] ids, string name, int capacity, int index, string className);
        Student GetStudentById(int id);
    }
    public class StudentRepository : BaseRepository<Student, int>, IStudentRepository
    {
        private readonly SMSContext context;
        public StudentRepository(SMSContext dbContext) : base(dbContext)
        {
            context = dbContext;
        }
        public Student GetStudentById(int id)
        {
            return context.Student.Where(s => s.Id == id).FirstOrDefault();
        }

        public List<Student> GetStudentList(int[] ids, string name, int capacity, int index, string className)
        {
            var query = context.Student.AsQueryable();
            if (ids != null && ids.Length > 0)
            {
                query = query.Where(s => ids.Contains(s.Id));
            }
            if (name != null)
            {
                query = query.Where(s => $"{s.FirstName} {s.LastName}".ToLower()
                .Contains(name.ToLower()) && s.Class.Name.ToLower().Contains(className.ToLower()));
            }
            return query
            .Skip((index - 1) * capacity)
            .Take(capacity).ToList();
        }
    }
}
