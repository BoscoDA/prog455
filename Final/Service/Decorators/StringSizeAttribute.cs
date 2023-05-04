using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Decorators
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class StringSizeAttribute : ValidationAttribute
    {
        public int Min { get; set; }

        public StringSizeAttribute(int min)
        {
            Min = min;
        }

        public override bool IsValid(object? value)
        {
            if (value == null || value is not string || ((string)value).Length < Min)
            {
                ErrorMessage = $"Password must be at lesat {Min} characters.";
                return false;
            }
            return true;
        }
    }
}
