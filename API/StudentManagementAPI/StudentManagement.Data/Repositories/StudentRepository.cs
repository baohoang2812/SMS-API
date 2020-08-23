using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagement.Data.Repository
{
    public interface IStudentRepository : IBaseRepository<Student, int>
    {
        List<Student> GetStudentList(string name, int capacity, int index, string className);
    }
    public class StudentRepository : BaseRepository<Student, int>, IStudentRepository
    {
        private readonly SMSContext context;
        public StudentRepository(SMSContext dbContext) : base(dbContext)
        {
            context = dbContext;
        }

        public List<Student> GetStudentList(string name, int capacity, int index, string className)
        {
            var listStudent = context.Student
            .Where(s => (s.FirstName + s.LastName).ToLower()
            .Contains(name.ToLower()) && s.Class.Name.ToLower().Contains(className.ToLower()))
            .Skip((index - 1) * capacity)
            .Take(capacity).ToList();
            return listStudent;
        }
    }
}
