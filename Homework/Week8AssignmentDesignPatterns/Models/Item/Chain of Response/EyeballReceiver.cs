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
        /// <summary>
        /// Processes requests of the ItemType EYEBALL and passes anyother request to the receivers next receiver.
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="ArgumentException">Execption is thrown is there is not receiver after this one.</exception>
        public override void ProcessRequest(IItem item)
        {
            if(item.Type == ItemType.EYEBALL)
            {
                Player.Instance().PickUpItem(item);

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
