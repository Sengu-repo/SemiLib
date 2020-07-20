using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semi
{
    public class ErrorEventArgs : EventArgs
    {
        public string Message { get; set; }

        public uint Code { get; set; }

        public ErrorEventArgs(string _message,uint _code)
        {
            this.Message = _message;

            this.Code = _code;
        }

    }
}
