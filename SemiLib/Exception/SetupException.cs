using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semi
{ 
    public class SetupException : Exception
    {
        public SetupException() : base()
        { }

        public SetupException(string message) : base(message)
        { }

    }
}
