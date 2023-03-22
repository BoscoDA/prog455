using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8AssignmentDesignPatterns.Enums;
using Week8AssignmentDesignPatterns.Models.Item;

namespace Week8AssignmentDesignPatterns.Models
{
    public class PotionReceiver : Receiver
    {
        /// <summary>
        /// Processes requests of the ItemType POTION and passes anyother request to the receivers next receiver.
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="ArgumentException">Execption is thrown is there is not receiver after this one.</exception>
        public override void ProcessRequest(IItem item)
        {
            if (item.Type == ItemType.POTION)
            {
                Player.Instance().PickUpItem(item);
                Console.WriteLine($"{item.Name} added to player inventory");
            }
            else if (nextReceiver != null)
            {
                nextReceiver.ProcessRequest(item);
            }
            else
            {
                throw new ArgumentException("Invalid Request");
            }
        }
    }
}
