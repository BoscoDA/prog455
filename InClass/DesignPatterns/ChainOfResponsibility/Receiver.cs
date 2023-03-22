using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    public abstract class Receiver : IReceiver
    {
        public IReceiver nextReceiver { get; set; }

        public void SetNextReceiver(IReceiver receiver)
        {
            this.nextReceiver = receiver;
        }

        public abstract void ProcessRequest(Item item);
    }
}
