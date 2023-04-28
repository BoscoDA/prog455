using GuessGame.Model;
using Services;
using Services.Model;


namespace GuessGame
{
    internal class Game
    {
        private DAL _dateService = new DAL();
        private Player _player;
        private DateTime _startStamp;
        private DateTime _endStamp;
        public Game(Player player)
        {
            _player = player;
        }

        public void Start()
        {
            _startStamp = DateTime.Now;
            int gameDuration = 0;
            int attempts = 1;
            var answer = new Random().Next(1, 11);

            int playerAnswer = 0;

            Console.Write($"{_player.Name} Please guess a number between 1 and 10:{Environment.NewLine}");
            string input = Console.ReadLine() ?? "";
            playerAnswer = string.IsNullOrEmpty(input) ? 0 : Int32.Parse(input);
            while (playerAnswer != answer)
            {
                Console.WriteLine("Please try again:");
                input = Console.ReadLine() ?? "";
                playerAnswer = string.IsNullOrEmpty(input) ? 0 : Int32.Parse(input);

                attempts++;
            }

            Console.WriteLine("Great Job!");
            _endStamp = DateTime.Now;
            gameDuration = (int)Math.Ceiling((_endStamp - _startStamp).TotalSeconds);
            Console.WriteLine($"# of Attempts:{attempts}");
            Console.WriteLine($"Game Duration:{gameDuration} seconds");

            RecordModel record = new RecordModel();
            record.PlayerName = _player.Name;
            record.Attempts = attempts;
            record.Duration = gameDuration;
            record.CorrectAnswer = answer;

            _dateService.InsertRecord(record);
            _dateService.APIInsertRecord(record);

        }
    }
}
