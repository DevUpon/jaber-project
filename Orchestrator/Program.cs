using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchestrator
{
    class Program
    {
        static void Main(string[] args)
        {
            Orchestrateur orch = new Orchestrateur(1);
            orch.Connecter();
            orch.WaitCompletedConnexion();
            orch.Envoyer("Hello!");
            orch.Recevoir();
        }
    }
}