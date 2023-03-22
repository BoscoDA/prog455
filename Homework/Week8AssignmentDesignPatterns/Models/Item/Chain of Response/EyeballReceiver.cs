using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8AssignmentDesignPatterns.Enums;
using Week8AssignmentDesignPatterns.Models.Item;
using Week8AssignmentDesignPatterns.Utilities;

namespace Week8AssignmentDesignPatterns
{
    public class EyeballReceiver : Receiver
    {
        public override void ProcessRequest(IItem item)
        {
            if(item.Type == ItemType.EYEBALL)
            {
                Player.Instance("").PickUpItem(item);

                Printer.Print($"{item.Name} added to player inventory", ConsoleColor.Gray);
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
