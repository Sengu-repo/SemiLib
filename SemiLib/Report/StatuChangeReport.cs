using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semi.Report
{
    public class StatuChangeReport : IReport
    {
        public string EqpID { get; set; }

        public string CtrlMode { get; set; }

        public string ProcMode { get; set; }    
    }
}
