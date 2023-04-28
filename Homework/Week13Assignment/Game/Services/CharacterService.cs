using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Week10DesignPatternII.Models;
using Week10DesignPatternII.Models.Items;

namespace Week10DesignPatternII.Services
{
    public class CharacterService
    {
        /// <summary>
        /// Validates the player passed in and outputs any errors encountered
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Handles setting the name of the character passed in.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="character"></param>
        public void SetName(string name, ICharacter character)
        {
            character.Name = name;
        }

        /// <summary>
        /// Sets the uniform color of the character passed in
        /// </summary>
        /// <param name="color"></param>
        /// <param name="character"></param>
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

        /// <summary>
        /// Sets the value of the character's gem stone
        /// </summary>
        /// <param name="gem"></param>
        /// <param name="character"></param>
        public void SetGemStone(string gem, ICharacter character)
        {
            character.GemStone = gem;
        }

        /// <summary>
        /// Updates states based off of the items in the players inventory
        /// </summary>
        /// <param name="character"></param>
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

        /// <summary>
        /// Adds a item to the player's inventory
        /// </summary>
        /// <param name="item"></param>
        /// <param name="character"></param>
        public void AddItemToInventory(IItem item, ICharacter character)
        {
            character.Inventory.Add(item);
        }

        /// <summary>
        /// Clears the players inventory
        /// </summary>
        /// <param name="character"></param>
        public void ClearInventory(ICharacter character)
        {
            character.Inventory.Clear();
        }
    }
}
