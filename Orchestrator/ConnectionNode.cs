using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Orchestrator
{
    class ConnectionNode : Connection
    {
        String nodeAddress;
        int nodePort;

        public ConnectionNode(string nodeAddress, int nodePort)
        {
            this.nodeAddress = nodeAddress;
            this.nodePort = nodePort;
        }

        public void StartClient()
        {
            this.Connect(nodeAddress, nodePort);
        }
    }
}
