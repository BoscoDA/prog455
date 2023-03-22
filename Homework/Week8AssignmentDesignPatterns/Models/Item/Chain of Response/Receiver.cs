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
        public abstract void ProcessRequest(IItem item);
        public void SetNextReceiver(Receiver receiver)
        {
            this.nextReceiver = receiver;
        }
    }
}
