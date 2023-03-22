using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public abstract class ArtifactBase : IArtifact
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public int Durability { get; set; }
        public int LevelRequirement { get; set; }

        public void PrintInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Name: {Name}{Environment.NewLine}");
            sb.Append($"Description: {Description}{Environment.NewLine}");
            sb.Append($"Durability: {Durability}{Environment.NewLine}");
            sb.Append($"LevelRequirement: {LevelRequirement}{Environment.NewLine}");

            Console.WriteLine( sb.ToString());
        }
    }
}
