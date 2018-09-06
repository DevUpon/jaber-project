using System;
namespace Nodes
{
    public class Node
    {
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
    }
}