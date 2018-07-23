using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchestrator
{
    class Orchestrator
    {
        private String dna;
        private ConnectionNode connectionNode;

        public String reduce(Dictionary<int, string> dna)
        {
            var strReturn = string.Empty;

            foreach (var entry in dna) {
                strReturn += entry.Value + entry.Key;
            }
            return strReturn;
        }
    }
}
