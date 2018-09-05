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
            Noeud n1 = new Noeud(0);
            orch.connecter();
            n1.connecter();
            orch.waitCompletedConnexion();
            orch.envoyer("Hello!");
        }
    }
}
