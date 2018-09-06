using System;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Text;
using Shared;

namespace Orchestrator
{
    public class ConnexionOrchestrateur : IConnexionOrchestrateur
    {
        private Socket socketOrchestrateur;
        private int nbrNoeuds;
        private ArrayList listeConnexions = new ArrayList();

        public ConnexionOrchestrateur(int nbrNoeuds)
        {
            this.nbrNoeuds = nbrNoeuds;
            socketOrchestrateur = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public ArrayList GetConnexions()
        {
            return listeConnexions;
        }

        public String GetAdresse()
        {
            IPEndPoint ipPoint = socketOrchestrateur.LocalEndPoint as IPEndPoint;
            if (ipPoint != null)
            {
                return ipPoint.Address.ToString();
            }
            else
            {
                return null;
            }
        }

        public String GetPort()
        {
            IPEndPoint ipPoint = socketOrchestrateur.LocalEndPoint as IPEndPoint;
            if (ipPoint != null)
            {
                return ipPoint.Port.ToString();
            }
            else
            {
                return null;
            }
        }

        public Boolean OuvrirConnexion()
        {
            IPAddress ipServer;
            if (IPAddress.TryParse("127.0.0.1", out ipServer))
            {
                socketOrchestrateur.Bind(new IPEndPoint(ipServer.MapToIPv4(), 50000));
                socketOrchestrateur.Listen(1);
                Socket handler = socketOrchestrateur.Accept();
                listeConnexions.Add(handler);
                Console.WriteLine("Node {0} connected", listeConnexions.Count);
                return true;
            }
            return false;
        }

        public void AccepterConnexion(IAsyncResult resultat)
        {
            listeConnexions.Add(socketOrchestrateur.EndAccept(resultat));
        }

        public Boolean FermerConnexion()
        {
            try
            {
                socketOrchestrateur.Shutdown(SocketShutdown.Both);
                socketOrchestrateur.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public Boolean VerifierConnexion()
        {
            return true;
        }

        public Boolean Envoyer(String donnees)
        {
            byte[] byteData = Encoding.ASCII.GetBytes(donnees);
            Socket client = (Socket)listeConnexions[0];
            client.Send(byteData);
            return true;
        }

        public void EnvoiCallBack(IAsyncResult resultat)
        {
            int bytesSent = socketOrchestrateur.EndSend(resultat);
            Console.WriteLine("Sent {0} bytes to server.", bytesSent);
        }

        public String Recevoir(Socket handler)
        {
            Console.WriteLine("travail");

            BufferObjet etatConnexion = new BufferObjet();
            etatConnexion.socketConnexion = socketOrchestrateur;
            String data = null;
            while (true)
            {
                int bytesRec = handler.Receive(etatConnexion.buffer);
                data = (String)Encoding.ASCII.GetString(etatConnexion.buffer, 0, bytesRec);
                if (data.Equals(String.Empty))
                {
                    break;
                }
                else
                {
                    etatConnexion.chaineBuffer += data;
                }
            }
            Console.WriteLine(etatConnexion.chaineBuffer);
            return etatConnexion.chaineBuffer;
        }

        public Socket GetSocket(Socket handler)
        {
            throw new NotImplementedException();
        }

        public string Recevoir()
        {
            throw new NotImplementedException();
        }
    }
}