using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Week10DesignPatternII.Models;

namespace Week10DesignPatternII.Services
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
                    character.UniformColor = ConsoleColor.DarkBlue;
                    break;
                case "2":
                    character.UniformColor = ConsoleColor.DarkGreen;
                    break;
                case "3":
                    character.UniformColor = ConsoleColor.DarkCyan;
                    break;
                case "4":
                    character.UniformColor = ConsoleColor.DarkRed;
                    break;
                default:
                    break;
            }
        }

        public void SetGemStone(string gem, ICharacter character)
        {
            character.GemStone = gem;
        }

        public void SetStats(ICharacter character)
        {
            foreach(var item in character.Inventory)
            {
                switch (item.Type)
                {
                    case "Boot":
                        character.Weight += item.StatChange;
                        break;
                    case "Suit":
                        character.Weight += item.StatChange;
                        character.HP += item.StatChange;
                        break;
                    default:
                        break;
                }
            }
            
        }
    }
}
