using Semi.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Semi.Report;

namespace Semi
{
    public class SemiManager
    {
        public static SemiManager Instance;

        EAP.Config config;

        Socket.SocketClient client;

        public EventHandler<ErrorEventArgs> ErrorEventHandler;

        // for tesing
        //
        public EventHandler<ReceivedEventArgs> ReceivedEventHandler;

        public EventHandler<SendEventArgs> SendEventHandler;

        public EventHandler<StatusEventArgs> StatusEventHandler;

        public bool Connected { get { return client.Connected; } }

        public SemiManager()
        {
            Instance = this;
        }

        public bool Setup(string _ip,int _port)
        {
            try
            {
                if (this.config == null)
                {
                    this.config = new EAP.Config();

                    if (this.config.IP != _ip || this.config.Port != _port)
                    {
                        config.IP = _ip;
                        config.Port = _port;
                    }
                }

                if (this.config != null)
                {
                    if (this.config.IP != _ip || this.config.Port != _port)
                    {
                        config.IP = _ip;
                        config.Port = _port;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new SetupException(ex.Message);
            }
        }

        public bool Connect()
        {
            try
            {
                client = new Socket.SocketClient(this.config);

                client.ErrorEventHandler += ErrorEventReceived;

                client.ReceivedEventHandler += ReceivedEvent;

                client.StatusEventHandler += StatusEventReceived;

                client.Connect();
            
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Disconnect()
        {
            try
            {
                if (client != null)
                {
                    if (client.Connected)
                    {
                        client.Disconnect();
                    }
                }
            }
            catch
            {
                return;
            }
        }

        public void SendReport<T>(REPORT_TYPE _type,T _obj, Model.Header _header, string _eqpID)
        {
            try
            {
                switch (_type)
                {
                    case REPORT_TYPE.EqpStatuChangeReport:
                        // Step 1: Check Validation of the object
                        //
                        if (!(_obj is Report.StatuChangeReport)) throw new ObjectValidationException();

                        // Step 2: Convert into JSON
                        //
                        string msg = SemiJSONHelper.GetString(_obj, _header,Model.MESSAGE_TYPE.REQUEST, _eqpID);

                        // step 3: Send to Server
                        //
                        if (!string.IsNullOrEmpty(msg))
                        {
                            SendAsyn(msg, true);
                        }

                        break;
                    case REPORT_TYPE.EqpAlarmReport:
                        if (!(_obj is Report.AlarmReport)) throw new ObjectValidationException();

                        // TO-DO

                        break;
                    case REPORT_TYPE.EqpEdcReport:
                        if (!(_obj is Report.EdcReport)) throw new ObjectValidationException();

                        // TO-DO

                        break;
                    default:
                        throw new ObjectValidationException("Object type invalid");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }


        public async void SendAsyn(string message,bool testing)
        {
            try
            {
                if (this.client.Connected)
                {
                    if (testing)
                    {
                        int i = 0;
                        while (testing)
                        {
                            this.client.SendAsync(message);

                            i++;

                            if (i > 3000)
                            {
                                break;
                            }
                             
                            // OnSendEvent(new SendEventArgs("Send: " + message));

                            await Task.Delay(300); // 0.3 Sec

                            if (!client.Connected)
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        this.client.SendAsync(message);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        #region Event Method

        private void ReceivedEvent(object sender, ReceivedEventArgs args)
        {
            System.Diagnostics.Debug.WriteLine("Received: "+ args.Message);

            // For testing
            OnReceiveEvent(new ReceivedEventArgs(args.Message));
        }

        private void ErrorEventReceived(object sender, ErrorEventArgs args)
        {
            OnErrorEventHandler(new ErrorEventArgs(args.Message,args.Code));
        }

        private void StatusEventReceived(object sender, StatusEventArgs _args)
        {
            OnStatusEvent(new StatusEventArgs(_args.Connected));
        }

        protected virtual void OnErrorEventHandler(ErrorEventArgs _args)
        {
            EventHandler<ErrorEventArgs> handler = ErrorEventHandler;

            if (handler != null)
            {
                handler(this, _args);
            }
        }

        protected virtual void OnReceiveEvent(ReceivedEventArgs _args)
        {
            EventHandler<ReceivedEventArgs> handler = ReceivedEventHandler;

            if (handler != null)
            {
                handler(this, _args);
            }
        }

        protected virtual void OnSendEvent(SendEventArgs _args)
        {
            EventHandler<SendEventArgs> handler = SendEventHandler;

            if (handler != null)
            {
                handler(this, _args);
            }

        }

        protected virtual void OnStatusEvent(StatusEventArgs _args)
        {
            EventHandler<StatusEventArgs> handler = StatusEventHandler;

            if (handler != null)
            {
                handler(this, _args);
            }

        }

        #endregion

    }
}
