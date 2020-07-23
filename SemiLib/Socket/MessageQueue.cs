using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semi.Socket
{
    public class MessageQueue
    {
        public System.Collections.Queue Messages = new System.Collections.Queue();

        public bool Processing;

        public event MessageQueuedEventHandler MessageQueued;

        public delegate void MessageQueuedEventHandler();

        public void Add()
        {

        }

    }
}
