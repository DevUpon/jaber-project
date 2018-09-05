using System;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Collections;

namespace Nodes
{
    public class TaskManager
    {
        private Task<String> tache;
        private Task<Boolean> tacheConnexion;
        private IConnexionSocket connexion;

        public TaskManager(IConnexionSocket connexion)
        {
            this.connexion = connexion;
        }

        public void runConnecter()
        {
            tacheConnexion = Task.Run(new Func<Boolean>(connexion.ouvrirConnexion));
            Console.WriteLine("Statut du task : {0}", tacheConnexion.Status);
        }

        public Boolean isConnected()
        {
            return tacheConnexion.IsCompleted;
        }

        public void runTaskRecevoir()
        {
            foreach (Socket socketConnexion in connexion.getConnexions()) {
                tache = Task.Run(() => connexion.recevoir(socketConnexion));
            }
                                      
        }

        public void wait()
        {
            tacheConnexion.Wait();
        }

        
    }
}
