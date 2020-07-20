using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semi
{
    public class SendNullException : Exception
    {
        public SendNullException() : base()
        { }

        public SendNullException(string message) : base(message)
        { }
    }
}
