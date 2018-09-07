<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nodes;

namespace Orchestrator
=======
﻿namespace Orchestrator
>>>>>>> 1c38a83d193af3e316d3e6b698f38dfea4f44db3
{
    class Program
    {
        static void Main(string[] args)
        {
            Maestro orch = new Maestro(1);
<<<<<<< HEAD
            List<List<String>> dnaList= orch.CreateDnaFragChunk(@"C:\Users\Faurever\Desktop\genomeTest.txt", 2);
            orch.Connecter(2);
=======
            orch.Connecter();
>>>>>>> 1c38a83d193af3e316d3e6b698f38dfea4f44db3
            orch.WaitCompletedConnexion();
            orch.Envoyer(dnaList);
            orch.Recevoir();
        }
    }
}