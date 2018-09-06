using System;
using System.Collections.Generic;

namespace Nodes
{
    public class Node
    {
        private List<String> dnaFragment;
        private IConnexionNode connexion;

        public Node()
        {
            connexion = new ConnexionNode();
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