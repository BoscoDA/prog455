using Service;
using Service.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Xml.Linq;
using Week10DesignPatternII.Models;
using Week10DesignPatternII.Models.Items;
using Week10DesignPatternII.Services;
using Week10DesignPatternII.Utilities;

namespace Week10DesignPatternII
{
    public class Game<T, U> where T : ICharacter
                              where U : ICharacter
    {
        private List<IItem> items = new List<IItem>();
        private CharacterService service = new CharacterService();
        private DAL _dataService = new DAL();

        /// <summary>
        /// Runs the game
        /// </summary>
        /// <param name="player"></param>
        /// <param name="cpu"></param>
        public void Start(T player, U cpu)
        {
            Menu();
            Gameloop(player, cpu);

            //Update final player state to the database using the API
            _dataService.APIUpdateRecord(CreateRecord(player));

            Printer.WaitForInput("\nPress any key to exit the game... ");
        }
        /// <summary>
        /// Displays instruction to the screen
        /// </summary>
        private void Menu()
        {
            Printer.Print("See if you can out dive the CPU.\n\n" +
                "- Your characters weight affects how for you dive each round." +
                "\n- Once you dive past 190ft water pressure will start to damage you.\n\n", ConsoleColor.Magenta);

            Printer.WaitForInput("\nPress any key to continue... ");

            Console.Clear();
        }
        /// <summary>
        /// Launchs the game's gameplay loop
        /// </summary>
        /// <param name="player"></param>
        /// <param name="cpu"></param>
        private void Gameloop(ICharacter player, ICharacter cpu)
        {
            Setup(player, cpu);
            Play(player, cpu);
        }
        /// <summary>
        /// Handles all the game setup up logic (Character Creatation(), SetUpCPU(), PopulateItems() and set player stats)
        /// </summary>
        /// <param name="player"></param>
        /// <param name="cpu"></param>
        private void Setup(ICharacter player, ICharacter cpu)
        {
            PopulateItems();

            SetUpCPU(cpu);

            CharacterCreation(player, null);
            service.SetStats(player);

            //add new player to the database using the API
            _dataService.APIInsertRecord(CreateRecord(player));

        }
        /// <summary>
        /// Handles logic for the play to set their name, uniform color, gem stone type and choose items
        /// </summary>
        /// <param name="player"></param>
        /// <param name="error"></param>
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
                service.ClearInventory(player);
                ChooseItems(player);
            }

            List<ValidationResult> errors = service.ValidateCharacter(player);

            if (errors.Count > 0)
            {
                Printer.WaitForInput("Press any key to correct the above errors...");
                Console.Clear();
                CharacterCreation(player, errors);
            }
        }
        /// <summary>
        /// Sets up all important values of the CPU
        /// </summary>
        /// <param name="cpu"></param>
        private void SetUpCPU(ICharacter cpu)
        {
            service.SetName("Dave", cpu);
            service.SetGemStone("emerald", cpu);
            cpu.UniformColor = ConsoleColor.Cyan;
            service.AddItemToInventory(items[new Random().Next(0, items.Count)],cpu);
            service.AddItemToInventory(items[new Random().Next(0, items.Count)], cpu);

            service.SetStats(cpu);
        }
        /// <summary>
        /// Populates the items lists with all items needed for the game
        /// </summary>
        private void PopulateItems()
        {
            items.Add(new Item("Iron Boots", "Boots made of iron.\n\nStat Effects:\n+30 Weight", 30, "Boot"));
            items.Add(new Item("Flippers", "Light weight diving flippers.\n\nStat Effects:\n-30 Weight", -30, "Boot" ) );
            items.Add(new Item("Iron Flippers", "Diving flippers made of iron.\n\nStat Effects:\n10 Weight", 10, "Boot") );

            items.Add(new Item("Lead Vest", "A vest made of lead.\n\nStat Effects:\n+50 Weight\n+50 HP", 50, "Suit") );
            items.Add(new Item("Wet Suit", "A typical wet suit.\n\nStat Effects:\n-50 Weight\n-50 HP", -50, "Suit"));
            items.Add(new Item("Reinforced Wet Suit", "A strong wet suit that can stand up to water pressure better.\n\nStat Effects:\n+25 Weight\n+25 HP", 25, "Suit"));
        }
        /// <summary>
        /// Handles logic for player to browse and choose items
        /// </summary>
        /// <param name="character"></param>
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
                        service.AddItemToInventory(items[itemIndex], character);
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
        /// <summary>
        /// Kicks off the gameplay portion of the class
        /// </summary>
        /// <param name="player"></param>
        /// <param name="cpu"></param>
        private void Play(ICharacter player, ICharacter cpu)
        {
            WaterPressure pressure = new WaterPressure();

            while (player.HP > 0 && cpu.HP > 0)
            {
                PlayRound(player, cpu, pressure);
            }
        }
        /// <summary>
        /// Handles logic to play a full round of the game. Player goes, CPU goes and water pressure damage inflicted
        /// </summary>
        /// <param name="player"></param>
        /// <param name="cpu"></param>
        /// <param name="pressure"></param>
        private void PlayRound(ICharacter player, ICharacter cpu, WaterPressure pressure)
        {
            TakeTurn(player, pressure);
            TakeTurn(cpu, pressure);

            pressure.DealDamage();

            DisplayHud(player, cpu);
        }

        /// <summary>
        /// Handles making the passed in character dive a certain number of feet
        /// </summary>
        /// <param name="character"></param>
        /// <param name="pressure"></param>
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

        /// <summary>
        /// Displays score screen comparing player and cpu health and depth dived
        /// </summary>
        /// <param name="player"></param>
        /// <param name="cpu"></param>
        private void DisplayHud(ICharacter player, ICharacter cpu)
        {
            Printer.Print($"\n{player.Name} | HP: {player.HP} |Depth Dived: {player.DepthDived}", ConsoleColor.Magenta);
            Printer.Print($"\n{cpu.Name} | HP: {cpu.HP} |Depth Dived: {cpu.DepthDived}\n", ConsoleColor.Magenta);
        }

        private RecordModel CreateRecord(ICharacter character)
        {
            RecordModel record = new RecordModel();
            record.Id = character.Id.ToString();
            record.Name = character.Name;
            record.UniformColor = (int)character.UniformColor;
            record.Weight = character.Weight;
            record.HP = character.HP;
            record.DepthDived = character.DepthDived;
            record.GemStone = character.GemStone;

            return record;
        } 
    }
}
