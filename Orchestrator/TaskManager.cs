using System;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Collections;

namespace Orchestrator
{
    public class TaskManager
    {
        private Task<Boolean> tacheConnexion;
        private IConnexionOrchestrateur connexion;

        public TaskManager(IConnexionOrchestrateur connexion)
        {
            this.connexion = connexion;
        }

        public void RunConnecter()
        {
            tacheConnexion = Task.Run(new Func<Boolean>(connexion.OuvrirConnexion));
            Console.WriteLine("Statut du task : {0}", tacheConnexion.Status);
        }

        public Boolean IsConnected()
        {
            return tacheConnexion.IsCompleted;
        }

        public void Wait()
        {
            tacheConnexion.Wait();
        }


    }
}