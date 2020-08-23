using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using StudentManagement.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentManagement.Data.Repositories
{
    public interface IAdminRepository 
    {
        Admin FindByUsername(string username);

    }
    public class AdminRepository : IAdminRepository
    {
        private readonly SMSContext context;
        public AdminRepository(SMSContext dbContext)
        {
            context = dbContext;
        }

        public Admin FindByUsername(string username)
        {
            var user = context.Admin.Where(u => u.Username == username).FirstOrDefault();
            return user;
        }
    }
}
