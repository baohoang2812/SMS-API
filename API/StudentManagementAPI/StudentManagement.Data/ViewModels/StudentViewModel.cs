using AutoMapper;
using Newtonsoft.Json;
using StudentManagement.Data;
using System;

namespace StudentManagement.Data.ViewModels
{
    public class StudentViewModel
    {

    }
    public class StudentCreateViewModel : BaseViewModel<Student>
    {
        public string FirstName { get; set; }       
        public string LastName { get; set; }
        public string Address { get; set; }        
        public DateTime? DoB { get; set; }       
        public string Phone { get; set; }       
        public int? ClassId { get; set; }
    }
    public class StudentUpdateViewModel : BaseViewModel<Student>
    {
        public string FirstName { get; set; }       
        public string LastName { get; set; }       
        public string Address { get; set; }       
        public DateTime? DoB { get; set; }       
        public string Phone { get; set; }     
        public int? ClassId { get; set; }
    }
}
