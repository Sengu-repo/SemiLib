using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using Newtonsoft.Json;

using Semi.Report;
using Semi.Receive;

using Semi.Model;

namespace Semi
{
    internal static class SemiJSONHelper
    {
        public static string GetString<T>(T _obj, Model.Header _head, MESSAGE_TYPE _type, string _eqpID)
        {
            try
            {
                switch (_type)
                {
                    case MESSAGE_TYPE.REQUEST:

                        return requestObject(_obj, _head);

                    case MESSAGE_TYPE.RESPONSE:

                        return reponseMessage( _head, _eqpID);
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private static string requestObject<T>(T _obj, Header _head)
        {
            try
            {
                if (_obj is StatuChangeReport)
                {
                    var obj = _obj as StatuChangeReport;

                    sendReport(obj, _head);

                }
                else if (_obj is AlarmReport)
                {
                    var obj = _obj as AlarmReport;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return string.Empty;
        }

        #region Report 

        private static string sendReport(object _report, Model.Header _header)
        {
            try
            {
                string msg = string.Empty;

                RequestMessage message = new RequestMessage();
                message.Request = new Model.Request();
                message.Request.Header = _header;
                message.Request.Body = _report;

                msg  = JsonConvert.SerializeObject(message, Formatting.Indented);

                return msg;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        #endregion

        #region Response

        private static string reponseMessage(Header _header,string _eqpID)
        {
            string msg = string.Empty;

            Semi.Model.ResponseMessage message = new Semi.Model.ResponseMessage();
            message.Response = new Semi.Model.Response();

            message.Response.Header = _header;
            message.Response.Body = new Model.ReturnBody(_eqpID);

            message.Response.Return = new Semi.Model.Return();
            message.Response.Return.ReturnCode = "OK";
            message.Response.Return.ReturnMessage = "Data Acceppted";

            msg = JsonConvert.SerializeObject(message, Formatting.Indented);

            return msg;
        }
        #endregion

    }
}
