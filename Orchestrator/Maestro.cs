using Nodes;
using System;
using System.Collections.Generic;

namespace Orchestrator
{
    public class Maestro
    {
        private TaskManager manager;
        private IConnexionOrchestrateur connexion;
        private String dna;
        private List<String> dnaFragments; //store dna splitted in case of loss of connexion

        public Maestro(int type)
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
            manager.TaskRecevoir();
        }

        public void mapNode(List<Node> nodes)
        {
            if (dnaFragments.Count != 0)
            {
                int numberOfDnaLinePerNode = dnaFragments.Count/nodes.Count;
                //TODO fix mapping by using connection socket and splitting array into N nodes
            }
            }
        }
    }
}