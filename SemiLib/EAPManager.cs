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
                this.client = new Socket.SocketClient(this.config);

                this.client.Connect();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
    }
}
