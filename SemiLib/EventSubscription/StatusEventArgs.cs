using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semi
{
    public class StatusEventArgs : EventArgs
    {
        public bool Connected { get; set; }

        public StatusEventArgs(bool _connect)
        {
            this.Connected = _connect;
        }
    }
}
