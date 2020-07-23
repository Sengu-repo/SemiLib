using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semi
{
    /// <summary>
    /// JSON Format Validation
    /// </summary>
    public class Validation
    {

        public async Task Message(string _msg)
        {
            try
            {
                var obj = JsonConvert.DeserializeObject<Model.RequestMessage>(_msg);

                var request = obj.Request;

                var header = request.Header;

                await messageBody(request.Header.MessageName, request.Body.ToString(), header, requestObject);

            }
            catch (Exception ex)
            {

                throw;
            }

        }

        private async Task messageBody(string _msg, string _body, Model.Header _header, Action<Object, Model.Header> callback)
        {
            try
            {
                if (_msg == Report.REPORT_TYPE.EqpStatuChangeReport.ToString())
                {
                    var obj = JsonConvert.DeserializeObject<Report.StatuChangeReport>(_body);

                    callback(obj, _header);
                }
            }
            catch
            {
                return;
            }
        }

        private void requestObject(object _obj, Model.Header _header)
        {
            try
            {
                if (_obj is Report.StatuChangeReport)
                {
                    string msg = SemiJSONHelper.GetString(_obj, _header, Model.MESSAGE_TYPE.RESPONSE,"A");

                    if (SemiManager.Instance != null)
                    {
                        SemiManager.Instance.SendAsyn(msg, false);
                    }
                }
            }
            catch
            {
                return;
            }
        }


    }
}
