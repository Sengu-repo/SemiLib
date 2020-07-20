using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;

namespace Semi.EAP
{
    public class Config
    {
        /// <summary>
        /// Default value = "127.0.0.1"
        /// </summary>
        public string IP { get { return ip; } set { ip = value; } }

        /// <summary>
        /// Default value = "5003"
        /// </summary>
        public int Port { get { return port; } set { port = value; } }

        /// <summary>
        /// Maximum Received bytes
        /// </summary>
        public int BuffSize { get { return buffSize; } set { buffSize = value; } }


        public int TimeOut { get { return timeOut; } set { timeOut = value; } }


        string ip = "127.0.0.1";

        int port = 8001;

        int buffSize = 1024;

        int timeOut = 2000;
    }

    public enum ConnectionMode
    {
        Active,
        Passive
    }

}
