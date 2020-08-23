using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagement.Data
{
    public partial class Student
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(200)]
        public string LastName { get; set; }
        [StringLength(500)]
        public string Address { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DoB { get; set; }
        [StringLength(12)]
        public string Phone { get; set; }
        public int? ClassId { get; set; }

        [ForeignKey("ClassId")]
        [InverseProperty("Student")]
        public virtual Class Class { get; set; }
    }
}
