using System;
using System.Collections.Generic;

namespace StudentManagement.Data
{
    public partial class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
