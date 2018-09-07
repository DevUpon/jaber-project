using System;
<<<<<<< HEAD
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
=======
using Shared;
using System.Collections.Generic;
>>>>>>> 8450a98b6824e525db4a95bfd156b8b6d1e5ff33

<<<<<<< HEAD
/// </Bouchon>
=======
>>>>>>> 20aab16b997015dcb7d3efbd366aa089cf3519f1
namespace Nodes
{
    public class Node
    {
        private List<String> dnaFragment;
        private IConnexionNode connexion;
        private IReduce reduce;

        public Node()
        {
            //BOOOUUUCHOOOONNNN
            //connexion = new ConnexionNode();
            Parser parser = new Parser();
            Dictionary<string, int> dResult = parser.Parse("befqbesevqufdiqnsrodecfhqusyedvbcfnzer");
            Console.WriteLine("dict1");
            foreach (KeyValuePair < string, int> kvp in dResult)
            {
                //textBox3.Text += ("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }
            //BOOOUUUCHOOOONNNN 2
            Dictionary<string, int> dResult2 = parser.Parse("rodecfhqusyedvbcfnzrodecfhqusyedvbcfnzer");
            Dictionary<string, int> dResult3 = parser.Parse("befqbesevqufdiqnsrodecfhqusyedvbcfnzer");
            Dictionary<string, int> dResult4 = parser.Parse("befqfnzervqufdiqnsrodecfhqusyedvbcfnzer");
            Reducer reducer = new Reducer();
            reducer.AddDictToReduce(dResult);
            reducer.AddDictToReduce(dResult2);
            reducer.AddDictToReduce(dResult3);
            reducer.AddDictToReduce(dResult4);
            Dictionary<string, int> finalDict = reducer.Reduce();
            Console.WriteLine("reduce");
            foreach (KeyValuePair<string, int> kvp in finalDict)
            {
                //textBox3.Text += ("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }

        }

        public void Connecter()
        {
            connexion.OuvrirConnexion();
        }

        public void Envoyer(String data)
        {
            connexion.Envoyer(data);
        }

        public void Recevoir()
        {
            connexion.Recevoir();
        }

        public void setDnaFragment(List<String> dnaFragment)
        {
            if (dnaFragment.Count != 0)
            {
                this.dnaFragment = dnaFragment;

            } else
            {
                throw new Exception("Unsupported operation, list is empty");
            }
        }
    }
}