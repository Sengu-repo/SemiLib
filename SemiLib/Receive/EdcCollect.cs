using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semi.Receive
{
    /// <summary>
    /// 设备参数采集
    /// </summary>
    public class EdcCollect : IReceive
    {
        public string EqpID { get => this.eqpID; set => this.eqpID = value; }

        string eqpID;
    }

    /// <summary>
    /// Edc Collect Receive Parameter
    /// </summary>
    public class ReceiveParam {

        public string Name { get; set; }

        public string Value { get; set; }

    }
}
