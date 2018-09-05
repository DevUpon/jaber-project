using System;
namespace Nodes
{
    public class Noeud
    {
        private TaskManager manager;
        private IConnexionSocket connexion;

        public Noeud(int type)
        {
            connexion = new ConnexionOrchestrateur(1);
            this.manager = new TaskManager(connexion);
        }

        public void connecter()
        {
            this.manager.runConnecter();
        }

        public void envoyer(String data)
        {
            connexion.envoyer(data);
        }

        public void waitCompletedConnexion()
        {
            manager.wait();
        }

        public void recevoir()
        {
            manager.runTaskRecevoir();
        }
    }
}
