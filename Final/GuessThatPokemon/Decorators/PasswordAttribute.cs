using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GuessThatPokemon.Decorators
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class PasswordAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            /*
             * ^ - Starts with
             * $ - Ends with
             * [] - Range
             * () - Group
             * . - Single character once
             * + - one or more characters in a row
             * ? - optional preceding character match
             * \ - escape character
             * \n - new line
             * \d - digit
             * \D - non-digit
             * \s - white space
             * \S - non-white space
             * \w - alphanumeric/underscore character (word chars)
             * \W - non-word charactesr
             * {x,y} - Repeat low (x) to high (y) (no "y" means at least x, no ",y" means that many)
             * (x|y) - alternatice - x or y
             * [^x} - Anything but x (where x is whatever character you want)
             * 
             * Above cheat sheet and learning of the topic of Regex (regular expression) from this video:  https://www.youtube.com/watch?v=R5BcHIMZMxc
             */

            bool regexResult = Regex.IsMatch((string)value, @"([A-Z])") && Regex.IsMatch((string)value, @"([a-z])") && Regex.IsMatch((string)value, @"([0-9])") && Regex.IsMatch((string)value, @"([!@#$%^&*-])");
            if (value == null || value is not string || !regexResult)
            {
                ErrorMessage = "Password must contain a Upercase Letter, Number and Special Character (!@#$%^&*-).";
                return false;
            }
            
            return true;
        }
    }
}
