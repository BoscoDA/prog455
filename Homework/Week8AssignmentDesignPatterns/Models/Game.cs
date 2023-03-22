using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Week8AssignmentDesignPatterns.Models.Item;

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

        TimeSpan endTime = new TimeSpan(0,5,0);


        private void GameLoop()
        {
            timer.StartTimer();

            while(!loseGame && player.Inventory.Count < 6)
            {
                Console.WriteLine(mansion.DisplayFloor());

                GuessRiddle();

                eyeballReceiver.ProcessRequest(mansion.GetItem());

                mansion.LoadNextFloor();

                CheckLoseCondition();

                Console.Clear();
            }

            timer.StopTimer();

            Console.WriteLine(GameEnd());

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
                Console.WriteLine("Enter the number of your selection: ");

                string input = Console.ReadLine();
                string answer = mansion.GetRiddleAnswer().ToString();

                if (input == answer)
                {
                    Console.WriteLine("Correct!\n");
                    correct = true;
                }
                else
                {
                    Console.WriteLine("Incorrect! Please guess again!\n");
                    player.LoseLife();
                }

                CheckLoseCondition();
            }
        }

        public string GameEnd()
        {
            string endGameOutput;
            if(player.Lives == 0)
            {
                endGameOutput = "You ran out of lives...\nGame Over!";
            }
            else if (timer.GetTime() >= endTime)
            {
                endGameOutput = "Time is up...\nGame Over!";
            }
            else
            {
                endGameOutput = "You Win!";
            }

            return endGameOutput;
        }
    }
}
