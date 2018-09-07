using System;
using System.Net.Sockets;
using System.Threading.Tasks;


namespace Orchestrator
{
    public class TaskManager
    {
        private Task<String> tache;
        private Task<Boolean> tacheConnexion;
        private IConnexionOrchestrateur connexion;

        public TaskManager(IConnexionOrchestrateur connexion)
        {
            this.connexion = connexion;
        }

        public void RunConnecter(int countNode)
        {
            tacheConnexion = Task.Run(() => connexion.OuvrirConnexion(countNode));
            Console.WriteLine("Statut du task : {0}", tacheConnexion.Status);
        }

        public Boolean IsConnected()
        {
            return tacheConnexion.IsCompleted;
        }

        internal void TaskRecevoir()
        {
            foreach (Socket socketConnexion in connexion.GetConnexions())
            {
                tache = Task.Run(() => connexion.Recevoir(socketConnexion));
            }
        }

        public void Wait()
        {
            tacheConnexion.Wait();
        }


    }
}