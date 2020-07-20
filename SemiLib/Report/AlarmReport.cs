using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semi.Report
{
    public struct AlarmReport
    {
        public string EqpID { get => eqpId; set => eqpId = value; }

        public string AlarmID { get; set; }

        public string AlarmCode { get; set; }

        public string AlarmMessage { get; set; }

        private string eqpId;
    }
}
