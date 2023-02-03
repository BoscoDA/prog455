using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDemo
{
    internal class MessageService
    {
        public string ReturnMessage(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return "There is no name";
            }
            var newMessage = "Hello " + name;
            return newMessage;
        }
    }
}
