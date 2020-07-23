using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semi.Model
{

    public enum MESSAGE_TYPE
    {
        REQUEST,
        RESPONSE
    }

    #region Reply
    public struct RequestMessage
    {
        public Request Request;
    }
    #endregion

    public struct ResponseMessage
    {
        public Response Response;
    }

    /// <summary>
    /// Request Message
    /// </summary>
    public struct Request
    {
        public Header Header;

        // Body Object 
        //
        public object Body;
    }

    /// <summary>
    /// Request Message
    /// </summary>
    public struct Response
    {
        public Header Header;

        // Body Object 
        //
        public object Body;

        public Return Return;
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
    /// Message Reutrn Code
    /// </summary>
    public struct Return
    {
        /// <summary>
        /// ReturnCode -> OK/NG/NA
        /// </summary>
        public string ReturnCode;

        public string ReturnMessage;
    }

    public struct ReturnBody
    {
        public string EqpID;

        public ReturnBody(string _id)
        {
            this.EqpID = _id;
        }
    }
}
