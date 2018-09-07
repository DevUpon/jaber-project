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
            Maestro orch = new Maestro(1);
            orch.Split();
            orch.Connecter();
            orch.WaitCompletedConnexion();
            orch.Envoyer("Hello!");
            orch.Recevoir();
            //orch.Split();
        }
    }
}