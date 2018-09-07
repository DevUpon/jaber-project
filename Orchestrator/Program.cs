using System;
using System.Collections.Generic;

namespace Orchestrator
{
    class Program
    {
        static void Main(string[] args)
        {
            Maestro orch = new Maestro(1);
            List<List<String>> dnaList= orch.CreateDnaFragChunk(@"C:\Users\Faurever\Desktop\genomeTest.txt", 2);
            orch.Connecter(2);
            orch.WaitCompletedConnexion();
            orch.Envoyer(dnaList);
            orch.Recevoir();
        }
    }
}