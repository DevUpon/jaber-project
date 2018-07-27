using System.Net.Sockets;

namespace Orchestrator
{
    class Connection : Socket
    {
        public Connection(SocketInformation socketInformation) : base(socketInformation)
        {
        }

        public Connection(SocketType socketType, ProtocolType protocolType) : base(socketType, protocolType)
        {
        }

        public Connection(AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType) : base(addressFamily, socketType, protocolType)
        {
        }

        }
}
