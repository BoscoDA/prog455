using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week10DesignPatternII.Models
{
    public class WaterPressure
    {
        public List<ICharacter> characters = new List<ICharacter>();
        public int maxDamage;
        public int minDamage;

        public int actualWaterPressureDamage;

        public void DealDamage(int min = 1, int max = 6)
        {
            maxDamage = max;
            minDamage = min;
            actualWaterPressureDamage = 0;

            Notify();
        }

        public void Notify()
        {
            foreach (var character in characters)
            {
                if (character.HP > 0)
                {
                    actualWaterPressureDamage = new Random().Next(minDamage, maxDamage) * (character.DepthDived/50);
                    character.Update(this);
                }
            }
        }

        public void Attach(ICharacter character)
        {
            if (!characters.Contains(character))
            {
                characters.Add(character);
            }
        }

        public void Remove(ICharacter character)
        {
            characters.Remove(character);
        }

    }
}
