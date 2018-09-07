using System;
using System.Collections.Generic;
using System.IO;

namespace Orchestrator
{
    class Program
    {
        static void Main(string[] args)
        {
            Maestro orch = new Maestro(1);
            List<List<String>> dnaList= orch.CreateDnaFragChunk(@"C:\temp\DNAFile.txt", 2);
            orch.Connecter(2);
            orch.WaitCompletedConnexion();
            orch.Envoyer(dnaList);
            string result = orch.Recevoir();
            Dictionary<string, int> reducing = orch.ReduceString(result);
            Console.WriteLine(reducing);

            string path = @"C:\temp\ResultFile.txt";
            using (StreamWriter outputFile = new StreamWriter(path))
            {
                foreach(var line in reducing)
                {
                    outputFile.WriteLine("[{0} : {1}]", line.Key, line.Value);
                }
            }
        }
    }
}