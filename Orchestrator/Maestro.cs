using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace Orchestrator
{
    class Maestro
    {
        private String dna;
        private ConnectionNode connectionNode;

        public Maestro(string dna, ConnectionNode connectionNode)
        {
            this.dna = dna;
            this.connectionNode = connectionNode;
        }

        public String reduce(Dictionary<int, string> dna)
        {
            var strReturn = string.Empty;

            foreach (var entry in dna)
            {
                strReturn += entry.Value + entry.Key;
            }
            return strReturn;
        }

        public void connect()
        {
            connectionNode.StartClient();
        }
    }
}
