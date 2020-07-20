using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semi.Report
{
    /// <summary>
    /// EQP 上报 /- REPORT 
    /// </summary>
    public enum REPORT_TYPE
    {
        /// <summary>
        /// 设备状态变化上报，包括断开，连接 /-  machine status changes report, include disconnection and connection
        /// </summary> 
        EqpStatuChangeReport = 0,

        /// <summary>
        /// 设备报警上报 /- machine alarm report
        /// </summary>
        EqpAlarmReport,

        /// <summary>
        /// 同步设备时间 /-  machine sync time
        /// </summary>
        EqpEdcReport,
    }

}
