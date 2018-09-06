using System;
namespace Nodes
{
    public class Noeud
    {
        private IConnexionNoeud connexion;

        public Noeud(int type)
        {
            connexion = new ConnexionNoeud();
        }

        public void Connecter()
        {
            connexion.OuvrirConnexion();
        }

        public void Envoyer(String data)
        {
            connexion.Envoyer(data);
        }

        public void WaitCompletedConnexion()
        {
            //TODO
        }

        public void Recevoir()
        {
            connexion.Recevoir();
        }
    }
}