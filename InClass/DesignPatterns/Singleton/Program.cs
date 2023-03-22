
using Singleton;

Console.WriteLine("Creating CounterA");
Counter counterA = Counter.GetInstance;



Console.WriteLine($" Counter A => {counterA.GetCount()}");
Console.WriteLine($" Counter A => {counterA.GetCount()}");

Console.WriteLine("Creating CounterB");
Counter counterB = Counter.GetInstance;

Console.WriteLine($" Counter B => {counterB.GetCount()}");
Console.WriteLine($" Counter A => {counterA.GetCount()}");

if ( counterA == counterB)
{
    Console.WriteLine("CounterA is the same instance as counterB");
}

Console.ReadKey();