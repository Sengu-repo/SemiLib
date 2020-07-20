using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semi
{
    public class EAPManager
    {
        EAP.Config config;

        Socket.SocketClient client;

        public EventHandler<ErrorEventArgs> ErrorEventHandler;

        // for tesing
        //
        public EventHandler<ReceivedEventArgs> ReceivedEventHandler;

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

                client.Connect();
            
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

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


    }
}
