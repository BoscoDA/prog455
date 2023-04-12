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

        /// <summary>
        /// Damages subscribers
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public void DealDamage(int min = 1, int max = 6)
        {
            maxDamage = max;
            minDamage = min;
            actualWaterPressureDamage = 0;

            Notify();
        }

        /// <summary>
        /// Notifies subscribers that damage is to be done to them
        /// </summary>
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

        /// <summary>
        /// Subscribes a observer to the subject
        /// </summary>
        /// <param name="character"></param>
        public void Attach(ICharacter character)
        {
            if (!characters.Contains(character))
            {
                characters.Add(character);
            }
        }

        /// <summary>
        /// Unsubscribes a observer from the subject
        /// </summary>
        /// <param name="character"></param>
        public void Remove(ICharacter character)
        {
            characters.Remove(character);
        }

    }
}
