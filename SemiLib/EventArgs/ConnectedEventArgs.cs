using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semi
{
    public class ConnectedEventArgs: EventArgs 
    {
        public string Client { get; set; }

        public ConnectedEventArgs(string _client)
        {
            this.Client = _client;
        }
    }
}
