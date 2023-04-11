using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week10DesignPatternII
{
    public class CharacterService
    {
        public void ValidateCharacter(Character character)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            var validationContext = new ValidationContext(character, null, null);

            var isValid = Validator.TryValidateObject(character, validationContext, errors, true);

            foreach (var error in errors)
            {
                foreach (var mem in error.MemberNames)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"ERROR: Reason:{error.ErrorMessage}");
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
