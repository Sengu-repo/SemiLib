using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semi.Receive
{
    public struct RemoteCommand
    {
        public string EqpID { get => this.eqpID; set => this.eqpID = value; }

        public string RemoteType { get; set; }

        string eqpID;
    }
}
