using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8AssignmentDesignPatterns.Models.Item
{
    public abstract class Receiver
    {
        public Receiver nextReceiver { get; set; }
        /// <summary>
        /// Processes requests specific type and passes anyother request to the next receiver.
        /// </summary>
        /// <param name="item"></param>
        public abstract void ProcessRequest(IItem item);

        /// <summary>
        /// Sets the what the next receiver in the chain will be.
        /// </summary>
        /// <param name="receiver"></param>
        public void SetNextReceiver(Receiver receiver)
        {
            this.nextReceiver = receiver;
        }
    }
}
