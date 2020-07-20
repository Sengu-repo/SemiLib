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
    public struct EdcCollect
    {
        public string EqpID { get => this.eqpID; set => this.eqpID = value; }



        string eqpID;
    }

    /// <summary>
    /// Edc Collect Receive Parameter
    /// </summary>
    public struct ReceiveParam {

        public string Name { get; set; }

        public string Value { get; set; }

    }
}
