using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week10DesignPatternII.Decorators
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class GemTypeAttribute : ValidationAttribute
    {
        public string ValidGems { get; set; }
        private string[] validGems { get; set; }

        public override bool IsValid(object? value)
        {
            validGems = ValidGems.Split(',');
            if (value == null || !validGems.Contains(value))
            {
                ErrorMessage = $"{value} is not a valid gem type.";
                return false;
            }
            return true;
        }
    }
}
