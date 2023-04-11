
using Generics;

Penguin player1 = new Penguin() { Name = "Bat Penguin", HP = 1000, ATK = 100, DEF = 15 };
Penguin player4 = new Penguin() { Name = "Green Penguin", HP = 800, ATK = 150, DEF = 13 };
Goofy player2 = new Goofy() { Name = "Green Goofy", HP = 1200, ATK = 120, DEF = 10 };
BattleCat player3 = new BattleCat() { Name = "Battle Kitty", HP = 900, ATK = 200, DEF = 16 };
Penguin player5 = new Penguin() { Name = "Penguin", HP = 1000, ATK = 100, DEF = 15 };
Penguin player6 = new Penguin() { Name = "Penguin", HP = 800, ATK = 150, DEF = 13 };
Goofy player7 = new Goofy() { Name = "Goofy", HP = 1200, ATK = 120, DEF = 10 };
BattleCat player8 = new BattleCat() { Name = "Kitty", HP = 900, ATK = 200, DEF = 16 };

//Game<Penguin, Goofy, BattleCat, Penguin> game = new Game<Penguin, Goofy, BattleCat,Penguin>();
//game.Fight(player1,player2,player3,player4);

List<IPlayer> list = new List<IPlayer>
{
    player1,
    player2,
    player3,
    player4,
    player5,
    player6,
    player7,
    player8
};

var game = new Game2<List<IPlayer>>();
game.Fight(list);

Console.ReadKey();