using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semi
{
    public class ClientNullException : Exception
    {
        public ClientNullException() : base()
        { }

        public ClientNullException(string message) : base(message)
        { }
    }
}
