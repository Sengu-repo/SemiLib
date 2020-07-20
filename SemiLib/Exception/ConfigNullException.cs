using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semi
{
    public class ConfigNullException : Exception
    {
        public ConfigNullException() : base()
        { }

        public ConfigNullException(string message) : base(message)
        { }
    }
}
