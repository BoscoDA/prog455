using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    internal class PotionReciever : IReceiver
    {
        

        public IReceiver nextReceiver { get; set; }

        public void ProcessRequest(Item item)
        {
            if (item.Name.Contains("Potion"))
            {
                Console.WriteLine($"PotionReciever processed {item.Quantity}{item.Name}s");
            }
            else
            {
                nextReceiver.ProcessRequest(item);
            }
        }

        public void SetNextReceiver(IReceiver receiver)
        {
            this.nextReceiver = receiver;
        }
    }
}
