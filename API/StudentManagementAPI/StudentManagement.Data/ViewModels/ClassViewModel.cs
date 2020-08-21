using AutoMapper;
using System;

namespace StudentManagement.Data.ViewModels
{
    public class ClassViewModel
    {
    }

    public class ClassCreateViewModel : BaseViewModel<Class>
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    public class ClassUpdateViewModel : BaseViewModel<Class>
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
