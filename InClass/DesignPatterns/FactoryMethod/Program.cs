using FactoryMethod;

List<Spawn> Spawns = new List<Spawn>();

Spawns.Add(new GremlinSpawn());
Spawns.Add(new HumanSpawn());

foreach ( var spawn in Spawns)
{
    var player = spawn.FactoryMethdod();
    Console.WriteLine(player.Name);
}