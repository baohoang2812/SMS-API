using System;
using System.Collections.Generic;

namespace StudentManagementAPI.Models
{
    public partial class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime? DoB { get; set; }
        public string Phone { get; set; }
        public int? ClassId { get; set; }
    }
}
