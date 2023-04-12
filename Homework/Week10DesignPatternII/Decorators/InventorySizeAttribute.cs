using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week10DesignPatternII.Models.Items;

namespace Week10DesignPatternII.Decorators
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class InventorySizeAttribute : ValidationAttribute
    {
        public int MaxItems { get; set; }

        public override bool IsValid(object? value)
        {
            if(value == null || value is not List<IItem> || ((List<IItem>)value).Count() > MaxItems){
                ErrorMessage = $"Player can't carry more than {MaxItems} items in their inventory.";
                return false;
            }
            return true;
        }
    }
}
