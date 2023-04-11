using Observer;


Poison Poison = new Poison();
Poison.Attach(new Player() { Name = "Player 1", HP = 50 });
Poison.Attach(new Player() { Name = "Player 2", HP = 40 });
Poison.ActivatePoisonBarrier();

Console.ReadKey();