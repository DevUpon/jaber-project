using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Orchestrator
{
    class ConnectionNode : Connection
    {
        public ConnectionNode(SocketInformation socketInformation) : base(socketInformation)
        {
        }
    }
}
