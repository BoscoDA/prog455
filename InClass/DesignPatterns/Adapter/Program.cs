using Adapter;

Character character = new Character();
Console.WriteLine(character.Info());


List<Character> players = new List<Character>();


players.Add(new Player("Orc"));
players.Add(new Player("Dwarf"));

players.ForEach(p => Console.WriteLine(p.Info()));