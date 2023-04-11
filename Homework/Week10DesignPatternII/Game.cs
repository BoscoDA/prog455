using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Week10DesignPatternII
{
    internal class Game<T, U> where T : ICharacter
                              where U : ICharacter
    {
        public void Start(T player, U cpu)
        {
            Gameloop(player, cpu);
        }

        private void Gameloop(ICharacter player, ICharacter cpu)
        {
            CharacterCreation(player);
        }

        private void CharacterCreation(ICharacter player)
        {
            CharacterService service = new CharacterService();

            Console.Write("Please enter your characters name: ");
            string name = Console.ReadLine().Trim();
            service.SetName(name, player);

            Console.WriteLine("\n1.) Red\n2.) Blue\n3.) Green\n4.) Yellow");
            Console.Write("\n\nPlease enter the number of the uniform color you would like:");
            string color = Console.ReadLine().Trim();
            service.SetJerseyColor(color, player);
            
            //service.SetGemStone();

            List<ValidationResult> errors = service.ValidateCharacter(player);

            if(errors.Count > 0) 
            {
                CharacterCreation(player, errors);
            }
        }

        private void CharacterCreation(ICharacter player, List<ValidationResult> error)
        {
            CharacterService service = new CharacterService();

            if(error.Exists(x => x.MemberNames.Contains("Name")))
            {
                Console.Write("Please enter your characters name: ");
                string name = Console.ReadLine().Trim();
                service.SetName(name, player);
            }

            if(error.Exists(x => x.MemberNames.Contains("UniformColor")))
            {
                Console.WriteLine("\n1.) Red\n2.) Blue\n3.) Green\n4.) Yellow");
                Console.Write("\n\nPlease enter the number of the uniform color you would like:");
                string color = Console.ReadLine().Trim();
                service.SetJerseyColor(color, player);
            }

            //service.SetGemStone();

            List<ValidationResult> errors = service.ValidateCharacter(player);

            if (errors.Count > 0)
            {
                CharacterCreation(player, errors);
            }
        }
    }
}
