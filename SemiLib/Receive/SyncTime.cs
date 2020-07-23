using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semi.Receive
{
    public class SyncTime : IReceive
    {
        public string EqpID { get => this.eqpID; set => this.eqpID = value; }

        public string Dtime { get; set; }

        string eqpID;
    }
}
