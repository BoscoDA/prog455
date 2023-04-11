using Decorator;
using System.ComponentModel.DataAnnotations;

namespace Decorator
{
    public  class BuiltIn
    {
        public void Run(Player player)
        {
            player = new Player() { Description = "This string is longer than 15 chars!!!!!!!!!!!" };
            List<ValidationResult> errors = new List<ValidationResult>();
            var validationContext = new ValidationContext(player, null, null);

            var isValid = Validator.TryValidateObject(player, validationContext, errors, true);

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
