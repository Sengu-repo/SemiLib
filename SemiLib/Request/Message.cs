using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semi.Request
{
    #region Request
    public struct Message
    {
        public Request Request;
    }
    #endregion

    /// <summary>
    /// Request Message
    /// </summary>
    public struct Request
    {
        public Header Header;

        public Body Body;
    }

    /// <summary>
    /// Request and Response Header
    /// </summary>
    public struct Header
    {
        /// <summary>
        /// 设备 ID 或者设备
        /// </summary>
        public string MachineName;
        /// <summary>
        /// UUID
        /// </summary>
        public string TransactionID;
        /// <summary>
        /// EqpStatuChangeReport, EqpAlarmReport, etc....
        /// </summary>
        public string MessageName;
        /// <summary>
        /// 登录用户名
        /// </summary>
        public string UserName;

        public string EventTime;

    }

    /// <summary>
    /// Message body
    /// </summary>
    public struct Body
    {
        /// <summary>
        /// body object
        /// </summary>
        public object body;
    }
}
