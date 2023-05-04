using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week10DesignPatternII.Decorators
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, 
        AllowMultiple = false, Inherited = true)]
    public class NameLengthAttribute : ValidationAttribute
    {
        public int Max { get; set; }
        public int Min { get; set; } = 1;

        public override bool IsValid(object? value)
        {
            if(value == null || ((string)value).Length > Max || ((string)value).Length < Min){
                ErrorMessage = $"Player name is invalid, name cannot be more than {Max} characters or empty.";
                return false;
            }
            return true;
        }
    }
}
