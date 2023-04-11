using Decorator;
using System.ComponentModel.DataAnnotations;


new BuiltIn().Run(new Player());

new BuiltIn().Run(new Player() { Inventory = new List<string>() { "Sword", "Shield"} });


Console.ReadKey();