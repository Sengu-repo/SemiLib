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

        #region EventHandler

        public EventHandler<ErrorEventArgs> ErrorEventHandler;
 
        public EventHandler<ReceivedEventArgs> ReceivedEventHandler;

        public EventHandler<StatusEventArgs> StatusEventHandler;
        #endregion

        public SocketClient(Config _config)
        {
            this.config = _config;
        }

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

        public async Task Connect()
        {
            try
            {
                setup();
            }
            catch (Exception ex)
            {
                OnErrorEventHandler(new ErrorEventArgs(ex.ToString(), (uint)E_CODE.SOCKET_CONNECT_CONFIG));
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

                    OnErrorEventHandler(new ErrorEventArgs("Server connecting task time out", (uint)E_CODE.SOCKET_CONNECT_TIMEOUT));
                }

                OnStatusEvent(new StatusEventArgs(true));

                await ReadAsync(client);

            }
            catch (Exception ex)
            {
                OnErrorEventHandler(new ErrorEventArgs(ex.ToString(), (uint)E_CODE.SOCKET_CONNECT_NULL));
            }
        }

        public async Task SendAsync(string message)
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

                    OnErrorEventHandler(new ErrorEventArgs("Message send task time out", (uint)E_CODE.SOCKET_SEND_TIMEOUT));
                }

                Debug.WriteLine(string.Format("Message was successfully send to Server:{0}", message));


            }
        }

        public async Task ReadAsync(TcpClient _client)
        {
            try
            {
                System.IO.StreamReader rd = new StreamReader(_client.GetStream());

                char[] buff = new char[config.BuffSize];

                int readByteCount = 0;

                while (true)
                {
                    readByteCount = await rd.ReadAsync(buff, 0, buff.Length);

                    if (readByteCount <= 0)
                    {
                        if (client != null)
                        {
                            client.Close();
                        }
                        this.OnStatusEvent(new StatusEventArgs(false));

                        break;
                    }

                    OnReceivedEventHandler(new ReceivedEventArgs(new string(buff)));

                    Array.Clear(buff, 0, buff.Length);

                }
            }
            catch (Exception ex)
            {
                OnErrorEventHandler(new ErrorEventArgs(ex.ToString(), (uint)E_CODE.SOCKET_RECEIVE_MESSAGE));
            }
        }

        #region Event Handler Method

        protected virtual void OnReceivedEventHandler(ReceivedEventArgs _args)
        {
            EventHandler<ReceivedEventArgs> handler = ReceivedEventHandler;

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

        protected virtual void OnErrorEventHandler(ErrorEventArgs _args)
        {
            EventHandler<ErrorEventArgs> handler = ErrorEventHandler;

            if (handler != null)
            {
                handler(this, _args);
            }
        }
        #endregion

        #region Private instance 

        Config config;

        IPAddress ipAddress;

        int port;

        int buffSize;

        TcpClient client;

        #endregion
    }
}
