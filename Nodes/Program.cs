using System;
using System.Collections.Generic;

namespace Nodes
{
    class Program
    {
        static void Main(String[] args)
        {
            Node n1 = new Node();
            n1.Connecter();
            String data = n1.Recevoir();
            Dictionary<string, int> resultReduce = n1.Reduce(data);
            string stringResult = n1.GetStringReduce(resultReduce);
            n1.Envoyer(stringResult);
        }
    }
}
