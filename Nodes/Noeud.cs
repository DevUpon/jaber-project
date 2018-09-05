using System;
namespace Nodes
{
    public class Noeud
    {
        private TaskManager manager;
        private IConnexionSocket connexion;
        private Boolean isOrch;
        public Noeud(int type)
        {
            if (type == 0)
            {
                connexion = new ConnexionNoeud();
                isOrch = false;
            }
            else
            {
                connexion = new ConnexionOrchestrateur(1);
                isOrch = true;
            }
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
    }
}
