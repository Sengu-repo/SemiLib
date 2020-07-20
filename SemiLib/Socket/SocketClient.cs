using System.Net;
using System.Net.Sockets;

using System.Diagnostics;

using Semi.EAP;
using System;
using System.Threading.Tasks;
using System.IO;

namespace Semi.Socket
{
    public class SocketClient
    {

        public SocketClient(Config _config)
        {
            this.config = _config;
        }

        #region Setup
        private bool setup()
        {
            if (this.config != null)
            {
                try
                {
                    // Server IP Addreess
                    IPAddress ip = null;

                    if (!IPAddress.TryParse(this.config.IP, out ip))
                    {
                        throw new InvalidCastException();
                    }

                    this.ipAddress = ip;

                    // Server Port Number
                    if (this.config.Port <= 0 && this.config.Port > 65535)
                    {
                        throw new Exception(string.Format("Invalid port number given number: {0}.\nAction: Port number must between 1..65535.",port));
                    }

                    this.port = config.Port;

                    if (this.config.BuffSize <= 8 && this.config.BuffSize > 1024)
                    {
                        throw new Exception(string.Format("Invalid buffer size given number: {0}.\nAction: Message buffer size must between 8..1024.", port));
                    }

                    this.buffSize = this.config.BuffSize;

                    return true;
                }
                catch(Exception ex)
                {
                   throw new Exception(ex.ToString());
                }
            }

            throw new ConfigNullException(string.Format("Setup.Config: Null Reference Object"));      
        }
        #endregion

        public async Task Connect()
        {
            try
            {
                setup();
            }
            catch (Exception ex)
            {

                throw new SetupException(ex.ToString());
            }

            if (this.client == null)
            {
                this.client = new TcpClient();
            }

            Task taskTimeOut = Task.Delay(config.TimeOut);

            try
            {
               await await Task.WhenAny(this.client.ConnectAsync(this.ipAddress, this.port), taskTimeOut);

                if (taskTimeOut.IsCompleted)
                {
                    Debug.WriteLine("Waiting Task Start");

                    Task.Delay(3000).Wait();

                    Debug.WriteLine("TimeOuException");

                    throw new TimeoutException();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task Send(string message)
        {
            if (string.IsNullOrEmpty(message)) throw new SendNullException();

            if (this.client == null) throw new ClientNullException();

            if (this.client.Connected)
            {
                StreamWriter wr = new StreamWriter(this.client.GetStream());
                wr.AutoFlush = true;

                Task taskTimeOut = Task.Delay(3000);

                await await Task.WhenAny(wr.WriteAsync(message), taskTimeOut);

                if (taskTimeOut.IsCompleted)
                {
                    Debug.WriteLine(string.Format("Message was unsuccessful send to Server: {0}", "Time Out Error"));

                    throw new TimeoutException();
                }

                Debug.WriteLine(string.Format("Message was successfully send to Server:{0}", message));
            }
        }

        #region Private instance 

        Config config;

        IPAddress ipAddress;

        int port;

        int buffSize;

        TcpClient client;

        #endregion
    }
}
