using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Xml.Linq;
using Week8AssignmentDesignPatterns.Models.Item;
using Week8AssignmentDesignPatterns.Utilities;

namespace Week8AssignmentDesignPatterns.Models
{
    public class Game
    {
        public Player player { get; set; }
        public Mansion mansion { get; set; }
        public GameTimer timer { get; set; }

        public Receiver eyeballReceiver = new EyeballReceiver();
        public Receiver potionReceiver = new PotionReceiver();
        public Receiver keyReceiver = new KeyReceiver();

        bool loseGame = false;

        TimeSpan endTime = new TimeSpan(0, 5, 0);

        private void GameLoop()
        {
            timer.StartTimer();

            while(!loseGame && player.Inventory.Count < 6)
            {
                DisplayHud();
                
                GuessRiddle();

                eyeballReceiver.ProcessRequest(mansion.GetItem());

                Printer.Print("\nPress any key to continue to the next floor...", ConsoleColor.Yellow);
                Console.ReadKey();

                mansion.LoadNextFloor();

                CheckLoseCondition();

                Console.Clear();
            }

            timer.StopTimer();

            GameEnd();

            Console.ReadKey();
        }

        public void CheckLoseCondition()
        {
            if(timer.GetTime() < endTime && player.Lives > 0)
            {
                loseGame = false;
            }
            else
            {
                loseGame = true;
            }
        }

        public void Start()
        {
            player = Player.Instance("Test");
            mansion = new Mansion();
            timer = GameTimer.GetInstance;

            eyeballReceiver.SetNextReceiver(potionReceiver);
            potionReceiver.SetNextReceiver(keyReceiver);

            GameLoop();
        }

        public void GuessRiddle()
        {
            bool correct = false;

            while (!correct && !loseGame)
            {


                Printer.Print("\nEnter the number of your selection: ", ConsoleColor.Yellow);

                string input = Console.ReadLine();
                string answer = mansion.GetRiddleAnswer().ToString();

                if (input == answer)
                {
                    Printer.Print("\nCorrect!\n", ConsoleColor.Green);
                    correct = true;
                }
                else
                {
                    player.LoseLife();
                    DisplayHud();

                    Printer.Print("Incorrect! Please guess again!\n", ConsoleColor.Red);
                    
                }

                CheckLoseCondition();
            }
        }

        public void GameEnd()
        {
            if(player.Lives == 0)
            {
                Printer.Print("You ran out of lives...\nGame Over!", ConsoleColor.Red);
            }
            else if (timer.GetTime() >= endTime)
            {
                Printer.Print("Time is up...\nGame Over!", ConsoleColor.Red);
            }
            else
            {
                Printer.Print("You Win!", ConsoleColor.Green);
            }
        }

        public void DisplayHud()
        {
            Console.Clear();

            Printer.Print("Lives: ", ConsoleColor.Magenta);
            for(int i = 1; i <= player.Lives; i++)
            {
                Printer.Print("\u2665", ConsoleColor.Red);
            }
            Printer.Print("\n", ConsoleColor.Magenta);


            Printer.Print("--------------Inventory--------------\n", ConsoleColor.Magenta);
            int inventoryCounter = 1;
            foreach (IItem i in player.Inventory)
            {
                Printer.Print($"{inventoryCounter}.) {i.Name}: ", ConsoleColor.White);
                Printer.Print($"{i.Description}\n", ConsoleColor.Gray);

                inventoryCounter++;
            }
            Printer.Print("-------------------------------------\n\n", ConsoleColor.Magenta);

            Printer.Print(mansion.DisplayFloor(), ConsoleColor.Magenta);
            Printer.Print(mansion.DisplayFloorRiddle(), ConsoleColor.White);
        }
    }
}
