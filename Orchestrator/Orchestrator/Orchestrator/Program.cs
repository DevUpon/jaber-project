using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nodes
{
    class Program
    {
        static void Main(string[] args)
        {
            Noeud orch = new Noeud(1);
            orch.connecter();
            orch.waitCompletedConnexion();
            orch.envoyer("Hello!");
            orch.recevoir();
        }
    }
}
