using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semi
{
    public class SendEventArgs : EventArgs
    {
        public string Message { get; set; }

        public SendEventArgs(string _message)
        {
            this.Message = _message;
        }
    }
}
