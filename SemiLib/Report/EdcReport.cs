using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semi.Report
{
    public class EdcReport : IReport
    { 
      public string EqpID { get; set; }

      public EdcParam[] ParaList { get; set; }
       
    }

    /// <summary>
    /// EQP to EQP Report Parameter
    /// </summary>
    public class EdcParam {

        public string Name { get; set; }

        public string Value { get; set; }

    }
}
