using StudentManagement.Data;
using StudentManagement.Data.Repositories;
using StudentManagement.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagement.Data.Services
{
    public interface IAdminService
    {
        bool CheckPassword(string username, string password);

        Admin FindByUsername(string username);
    }
    public class AdminService : IAdminService
    {
        private IAdminRepository adminRepository;
        public AdminService(IAdminRepository adminRepository) 
        {
            this.adminRepository = adminRepository;
        }

        public bool CheckPassword(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return false;
            }
            var user = adminRepository.FindByUsername(username);
            if(user != null)
            {
                if (user.Password == password)
                {
                    return true;
                }
            }
            return false;
        }

        public Admin FindByUsername(string username)
        {
            return adminRepository.FindByUsername(username);
        }
    }
}
