using GuessGame;
using GuessGame.Model;

Player player = new Player();


while (string.IsNullOrEmpty(player.Name))
{
    Console.WriteLine("Please enter your name:");
    player.Name = Console.ReadLine() ?? string.Empty;
}

Game game = new Game(player);
game.Start();