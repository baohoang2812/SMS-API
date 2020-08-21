using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace StudentManagement.Data.Extensions
{
    public static class EnumExtension
    {
        public static string DisplayName(this Enum item)
        {
            var type = item.GetType();
            var member = type.GetMember(item.ToString());
            var displayAttribute = (DisplayAttribute)member[0].GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault();
            if (displayAttribute != null)
            {
                return displayAttribute.Name;
            }
            return null;
        }
    }
}
