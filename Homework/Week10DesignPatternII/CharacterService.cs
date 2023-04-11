using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Week10DesignPatternII
{
    public class CharacterService
    {
        public List<ValidationResult> ValidateCharacter(ICharacter character)
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

            return errors;
        }

        public void SetName(string name, ICharacter character)
        {
            character.Name = name;
        }

        public void SetJerseyColor(string color, ICharacter character)
        {
            switch (color)
            {
                case "1":
                    character.UniformColor = ConsoleColor.Red;
                    break;
                case "2":
                    character.UniformColor = ConsoleColor.Blue;
                    break;
                case "3":
                    character.UniformColor = ConsoleColor.Green;
                    break;
                case "4":
                    character.UniformColor = ConsoleColor.Yellow;
                    break;
                default:
                    break;
            }
        }
    }
}
