using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8AssignmentDesignPatterns.Models.Item;

namespace Week8AssignmentDesignPatterns.Models
{
    public class PotionReceiver : Receiver
    {
        public override void ProcessRequest(IItem item)
        {
            if (item.Type == ItemFactory.ItemType.POTION)
            {
                Player.Instance("").PickUpItem(item);
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
