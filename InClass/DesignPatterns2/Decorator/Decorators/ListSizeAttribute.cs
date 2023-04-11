using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.Decorators
{
    //where it applies
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property,
AllowMultiple = false, Inherited = true)]
    public class ListSizeAttribute : ValidationAttribute
    {


        public int MaxItems { get; set; }
        

        public override bool IsValid(object value)
        {
            if (value == null || value is not List<object> || ((List<object>)value).Count() > MaxItems)
            {
                // can set error message here
                return false;
            }
            return true;
        }
    }
}

