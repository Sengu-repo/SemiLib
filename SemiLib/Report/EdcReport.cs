using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semi.Report
{
    public struct EdcReport
    { 
      public string EqpID { get; set; }

      public string[] ParaList { get; set; }
       
    }

    /// <summary>
    /// EQP to EQP Report Parameter
    /// </summary>
    public struct EdcParam {

        public string Name { get; set; }

        public string Value { get; set; }

    }
}
