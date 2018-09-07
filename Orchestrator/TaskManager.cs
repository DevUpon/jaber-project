using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Collections;


namespace Orchestrator
{
    public class TaskManager
    {
        private ArrayList taches;
        private Task<Boolean> tacheConnexion;
        private IConnexionOrchestrateur connexion;

        public TaskManager(IConnexionOrchestrateur connexion)
        {
            this.connexion = connexion;
            taches = new ArrayList();
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

        internal string TaskRecevoir()
        {
            string result = String.Empty;
            foreach (Socket socketConnexion in connexion.GetConnexions())
            {
                Task<string> tache = Task.Run(() => connexion.Recevoir(socketConnexion));
                taches.Add(tache);
            }

            Boolean terminated = true;
            do
            {
                terminated = true;
                foreach (Task tache in taches)
                {
                    if (tache.IsCompleted)
                    {
                        terminated = false;
                    }
                }
            } while (!terminated);

            foreach (Task<string> tache in taches)
            {
                result += (tache.Result.Trim() + ",");
            }
            return result.Substring(0, result.Length - 1).Trim();
        }

        public void Wait()
        {
            tacheConnexion.Wait();
        }


    }
}