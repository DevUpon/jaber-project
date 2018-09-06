using System;
namespace Orchestrator
{
    public class Orchestrateur
    {
        private TaskManager manager;
        private IConnexionOrchestrateur connexion;

        public Orchestrateur(int type)
        {
            connexion = new ConnexionOrchestrateur(1);
            this.manager = new TaskManager(connexion);
        }

        public void Connecter()
        {
            this.manager.RunConnecter();
        }

        public void Envoyer(String data)
        {
            connexion.Envoyer(data);
        }

        public void WaitCompletedConnexion()
        {
            manager.Wait();
        }

        public void Recevoir()
        {
            connexion.Recevoir();
        }
    }
}