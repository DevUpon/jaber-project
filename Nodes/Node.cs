using System;
using System.Collections.Generic;
using Shared;
using System.Threading.Tasks;



/// </Bouchon>

namespace Nodes
{
    public class Node
    {
        private List<String> dnaFragment;
        private IConnexionNode connexion;
        private Parser parser;
        private Reducer reducer;
        private Dictionary<string, int> result1;
        private Dictionary<string, int> result2;


        public Node()
        {
            //BOOOUUUCHOOOONNNN
            connexion = new ConnexionNode();
            parser = new Parser();
            reducer = new Reducer();
            // Dictionary<string, int> dResult = parser.Parse("befqbesevqufdiqnsrodecfhqusyedvbcfnzer");
            // Console.WriteLine("dict1");
            /*foreach (KeyValuePair < string, int> kvp in dResult)
            {
                //textBox3.Text += ("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            } */
            //BOOOUUUCHOOOONNNN 2
            /*Dictionary<string, int> dResult2 = parser.Parse("rodecfhqusyedvbcfnzrodecfhqusyedvbcfnzer");
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
            }*/

        }

        public Dictionary<string, int> Reduce(String data)
        {
            // Dictionary<string, int> parsing = parser.Parse(data);
            Task<Dictionary<string, int>> threadParse1 = Task.Run(() => parser.Parse(data.Substring(0, data.Length / 2)));
            Task<Dictionary<string, int>> threadParse2 = Task.Run(() => parser.Parse(data.Substring(data.Length / 2)));
            result1 = threadParse1.Result;
            result2 = threadParse2.Result;
            reducer.AddDictToReduce(result1);
            reducer.AddDictToReduce(result2);
            return reducer.Reduce();
        }

        public String GetStringReduce(Dictionary<string, int> data)
        {
            string result = String.Empty;
            foreach (string key in data.Keys)
            {
                result += key.Trim() + ":" + data[key].ToString() + ",";
            }
            return result.Substring(0, result.Length - 1) + "\n";
        }




        public void Connecter()
        {
            connexion.OuvrirConnexion();
        }

        public void Envoyer(String data)
        {
            connexion.Envoyer(data);
        }

        public String Recevoir()
        {
            return connexion.Recevoir();
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