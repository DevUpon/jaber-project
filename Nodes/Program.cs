using System;

namespace Nodes
{
    class Program
    {
        static void Main(String[] args)
        {
            Node n1 = new Node();
            n1.Connecter();
            String data = n1.Recevoir();
        }
    }
}
