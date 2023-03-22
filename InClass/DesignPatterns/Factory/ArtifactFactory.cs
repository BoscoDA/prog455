using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public static class ArtifactFactory
    {
        public static IArtifact CreateArtifact(string type, string name, string desc, int dur, int lvl)
        {
            IArtifact artifact;

            //Easier to use with a enum and switching on that enum
            switch (type)
            {
                case "Shield":
                    artifact = new Shield();
                    break;

                case "Helmet":
                    artifact = new Helmet();
                    break;

                default: throw new ArgumentException("Invalid Artifact Type");
            }

            artifact.Name = name;
            artifact.Description = desc;
            artifact.Durability = dur;
            artifact.LevelRequirement = lvl;

            return artifact;
        }
    }
}
