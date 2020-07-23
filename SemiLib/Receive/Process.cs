using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semi.Receive
{
    public class Process
    {
        Validation validation;

        public Process()
        {
            validation = new Validation();
        }

        public async void GetReply(string message)
        {
           await validation.Message(message);
        }
    }
}
