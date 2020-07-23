using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semi
{
    public class ObjectValidationException : Exception
    {
        public ObjectValidationException() : base()
        { }

        public ObjectValidationException(string message) : base(message)
        { }
    }
}
