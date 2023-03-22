using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8AssignmentDesignPatterns.Models.Item;

namespace Week8AssignmentDesignPatterns
{
    public class EyeballReceiver : Receiver
    {
        public override void ProcessRequest(IItem item)
        {
            if(item.Type == ItemFactory.ItemType.EYEBALL)
            {
                Player.Instance("").PickUpItem(item);

                Console.WriteLine($"{item.Name} added to player inventory");
            }
            else if(nextReceiver != null)
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
