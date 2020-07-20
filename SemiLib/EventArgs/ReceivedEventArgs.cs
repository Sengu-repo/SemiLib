using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semi
{
    public class ReceivedEventArgs : EventArgs
    {

        public string Message { get; set; }

        public ReceivedEventArgs(string _message)
        {
            this.Message = _message;
        }
    }
}
