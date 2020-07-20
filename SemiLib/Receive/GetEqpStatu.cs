using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semi.Receive
{
    public struct GetEqpStatu
    {
        public string EqpID { get => this.eqpID; set => this.eqpID = value; }

        public string CtrlMode { get; set; }

        public string ProcMode { get; set; }

        string eqpID;
    }
}
