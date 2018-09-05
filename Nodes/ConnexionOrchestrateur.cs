using System;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Text;


namespace Nodes
{
    public class ConnexionOrchestrateur : IConnexionSocket
    {
        private Socket socketOrchestrateur;
        private int nbrNoeuds;
        private ArrayList listeConnexions = new ArrayList();

        public ConnexionOrchestrateur(int nbrNoeuds)
        {
            this.nbrNoeuds = nbrNoeuds;
            socketOrchestrateur = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public ArrayList getConnexions()
        {
            return listeConnexions;
        }

        public String getAdresse()
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

        public String getPort()
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

        public Boolean ouvrirConnexion()
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

        public void accepterConnexion(IAsyncResult resultat)
        {
            listeConnexions.Add(socketOrchestrateur.EndAccept(resultat));
        }

        public Boolean fermerConnexion()
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

        public Boolean verifierConnexion()
        {
            return true;
        }

        public Boolean envoyer(String donnees)
        {
            byte[] byteData = Encoding.ASCII.GetBytes(donnees);
            Socket client = (Socket)listeConnexions[0];
            client.Send(byteData);
            return true;
        }

        public void envoiCallBack(IAsyncResult resultat)
        {
            int bytesSent = socketOrchestrateur.EndSend(resultat);
            Console.WriteLine("Sent {0} bytes to server.", bytesSent);
        }

        public String recevoir(Socket handler)
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
    }
}