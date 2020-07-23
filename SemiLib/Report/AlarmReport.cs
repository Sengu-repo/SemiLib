using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semi.Report
{
    public class AlarmReport : IReport
    {
        public string EqpID { get => eqpId; set => eqpId = value; }

        public string AlarmID { get; set; }

        public string AlarmCode { get; set; }

        public string AlarmMessage { get; set; }

        public string eqpId;
    }
}
