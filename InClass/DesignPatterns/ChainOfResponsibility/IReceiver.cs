using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    public interface IReceiver
    {
        IReceiver nextReceiver { get; set; }
        abstract void ProcessRequest(Item item);
        void SetNextReceiver(IReceiver receiver);
    }
}
