using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public interface IArtifact
    {
        string Name { get;set;}
        string Description { get; set;}
        int  Durability { get; set;}
        int LevelRequirement { get; set;}

    }
}
