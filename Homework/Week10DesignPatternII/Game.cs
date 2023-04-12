using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Week10DesignPatternII.Models;
using Week10DesignPatternII.Models.Items;
using Week10DesignPatternII.Services;
using Week10DesignPatternII.Utilities;

namespace Week10DesignPatternII
{
    internal class Game<T, U> where T : ICharacter
                              where U : ICharacter
    {
        private List<IItem> items = new List<IItem>();
        private CharacterService service = new CharacterService();

        public void Start(T player, U cpu)
        {
            Menu();
            Gameloop(player, cpu);
            Printer.WaitForInput("\nPress any key to exit the game... ");
        }

        private void Menu()
        {
            Printer.Print("See if you can out dive the CPU.\n\n" +
                "- Your characters weight affects how for you dive each round." +
                "\n- Once you dive past 190ft water pressure will start to damage you.\n\n", ConsoleColor.Magenta);

            Printer.WaitForInput("\nPress any key to continue... ");

            Console.Clear();
        }
        private void Gameloop(ICharacter player, ICharacter cpu)
        {
            Setup(player, cpu);
            Play(player, cpu);
        }

        private void Setup(ICharacter player, ICharacter cpu)
        {
            PopulateItems();

            SetUpCPU(cpu);

            CharacterCreation(player, null);
            service.SetStats(player);
        }

        private void CharacterCreation(ICharacter player, List<ValidationResult>? error)
        {
            if(error == null || error.Exists(x => x.MemberNames.Contains("Name")))
            {
                Printer.Print("Please enter your characters name: ", ConsoleColor.Magenta);
                string name = Console.ReadLine().Trim();
                service.SetName(name, player);
                Console.Clear();
            }

            if(error == null || error.Exists(x => x.MemberNames.Contains("UniformColor")))
            {
                Printer.Print("\n1.) Blue\n2.) Cyan\n3.) Green\n4.) Red\n\nPlease enter the number of the uniform color you would like: ", ConsoleColor.Magenta );
                string color = Console.ReadLine().Trim();
                service.SetJerseyColor(color, player);
                Console.Clear();
            }

            if(error == null || error.Exists(x => x.MemberNames.Contains("GemStone")))
            {
                Printer.Print("\n1.)Sapphire\n2.)Ruby\n3.)Emerald \n\nPlease enter the name of the gem stone you would like: ", ConsoleColor.Magenta);
                string gem = Console.ReadLine().Trim().ToLower();
                service.SetGemStone(gem, player);
                Console.Clear();
            }

            if(error == null || error.Exists(x => x.MemberNames.Contains("Inventory")))
            {
                player.Inventory.Clear();
                ChooseItems(player);
            }

            List<ValidationResult> errors = service.ValidateCharacter(player);

            if (errors.Count > 0)
            {
                CharacterCreation(player, errors);
            }
        }

        private void SetUpCPU(ICharacter cpu)
        {
            cpu.Name = "Dave";
            cpu.GemStone = "Emerald";
            cpu.UniformColor = ConsoleColor.Cyan;
            cpu.Inventory.Add(items[new Random().Next(0, items.Count)]);
            cpu.Inventory.Add(items[new Random().Next(0, items.Count)]);

            service.SetStats(cpu);
        }

        private void PopulateItems()
        {
            items.Add(new Item("Iron Boots", "Boots made of iron.\n\nStat Effects:\n+30 Weight", 30, "Boot"));
            items.Add(new Item("Flippers", "Light weight diving flippers.\n\nStat Effects:\n-30 Weight", -30, "Boot" ) );
            items.Add(new Item("Iron Flippers", "Diving flippers made of iron.\n\nStat Effects:\n10 Weight", 10, "Boot") );

            items.Add(new Item("Lead Vest", "A vest made of lead.\n\nStat Effects:\n+50 Weight\n+50 HP", 50, "Suit") );
            items.Add(new Item("Wet Suit", "A typical wet suit.\n\nStat Effects:\n-50 Weight\n-50 HP", -50, "Suit"));
            items.Add(new Item("Reinforced Wet Suit", "A strong wet suit that can stand up to water pressure better.\n\nStat Effects:\n+25 Weight\n+25 HP", 25, "Suit"));
        }

        private void ChooseItems(ICharacter character)
        {
            bool exit = false;
            int itemIndex = 0;

            while (!exit)
            {
                Printer.Print("Enter: 1.) Select Item | 2.) Next Item | 3.) Previous Item | 4.) Exit\n", ConsoleColor.Magenta);
                Printer.Print(items[itemIndex].Display(), ConsoleColor.Gray);
                Printer.Print("\nSelection: ", ConsoleColor.Magenta);

                string selection = Console.ReadLine().Trim();

                switch (selection)
                {
                    case "1":
                        character.Inventory.Add(items[itemIndex]);
                        break;
                    case "2":
                        itemIndex++;
                        if(itemIndex > items.Count - 1){itemIndex = 0;}
                        break;
                    case "3":
                        itemIndex--;
                        if (itemIndex < 0){itemIndex = items.Count -1;}
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        break;
                }

                Console.Clear();
            }
        }

        private void Play(ICharacter player, ICharacter cpu)
        {
            WaterPressure pressure = new WaterPressure();

            while (player.HP > 0 || cpu.HP > 0)
            {
                PlayRound(player, cpu, pressure);
            }
        }

        private void PlayRound(ICharacter player, ICharacter cpu, WaterPressure pressure)
        {
            TakeTurn(player, pressure);
            TakeTurn(cpu, pressure);

            pressure.DealDamage();

            DisplayHud(player, cpu);
        }

        private void TakeTurn(ICharacter character, WaterPressure pressure)
        {
            if(character.HP > 0)
            {
                int depthDived = new Random().Next(1 * (character.Weight / 8), 10 * (character.Weight / 8));
                Printer.Print($"\n{character.Name} dived down {depthDived}ft.", ((ConsoleColor)character.UniformColor));
                character.DepthDived += depthDived;

                if (character.DepthDived > 190)
                {
                    pressure.Attach(character);
                }
            }
        }

        private void DisplayHud(ICharacter player, ICharacter cpu)
        {
            Printer.Print($"\n{player.Name} | HP: {player.HP} |Depth Dived: {player.DepthDived}", ConsoleColor.Magenta);
            Printer.Print($"\n{cpu.Name} | HP: {cpu.HP} |Depth Dived: {cpu.DepthDived}\n", ConsoleColor.Magenta);
        }
    }
}
