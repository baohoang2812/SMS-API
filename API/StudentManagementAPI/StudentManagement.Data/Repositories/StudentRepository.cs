using Microsoft.EntityFrameworkCore;
using StudentManagement.Data.ViewModels;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagement.Data.Repository
{
    public interface IStudentRepository : IBaseRepository<Student, int>
    {
        List<Student> GetStudentList(int[] ids, string name, int capacity, int index, string className);
        Student UpdateWithoutImg(StudentUpdateViewModel model, int id);
        List<Student> GetStudentByClass(int classId);
    }
    public class StudentRepository : BaseRepository<Student, int>, IStudentRepository
    {
        private readonly SMSContext context;
        public StudentRepository(SMSContext dbContext) : base(dbContext)
        {
            context = dbContext;
        }

        public Student UpdateWithoutImg(StudentUpdateViewModel model, int id)
        {
            var selectedStudent = context.Student.Where(s => s.Id == id).FirstOrDefault();
            selectedStudent.FirstName = model.FirstName;
            selectedStudent.DoB = model.DoB;
            selectedStudent.Address = model.Address;
            selectedStudent.ClassId = model.ClassId;
            selectedStudent.LastName = model.LastName;
            selectedStudent.Phone = model.Phone;
            context.Student.Update(selectedStudent);
            context.SaveChanges();
            return selectedStudent;
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

        public List<Student> GetStudentByClass(int classId)
        {
            return context.Student.Where(s => s.ClassId == classId).ToList();
        }
    }
}
