using System;

namespace StudentManagement.Data.ViewModels
{
    public class ClassViewModel
    {
    }

    public class ClassCreateViewModel : BaseViewModel<Class>
    {
        public string Name { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }

    public class ClassUpdateViewModel : BaseViewModel<Class>
    {
        public string Name { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
