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

        public Socket getSocket()
        {
            return socketOrchestrateur;
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
                socketOrchestrateur.Bind(new IPEndPoint(ipServer.Address, 50000));
                socketOrchestrateur.Listen(nbrNoeuds);
                while (true)
                {
                    Socket handler = socketOrchestrateur.Accept();
                    listeConnexions.Add(handler);
                }
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
            Socket client = (Socket) listeConnexions[0];
            client.Send(byteData);
            return true;
        }

        public void envoiCallBack(IAsyncResult resultat)
        {
            int bytesSent = socketOrchestrateur.EndSend(resultat);
            Console.WriteLine("Sent {0} bytes to server.", bytesSent);
        }

        public String recevoir()
        {

            BufferObjet etatConnexion = new BufferObjet();
            etatConnexion.socketConnexion = socketOrchestrateur;
            String data = null;
            while (true)
            {
                int bytesRec = socketOrchestrateur.Receive(etatConnexion.buffer);
                data = (String)Encoding.ASCII.GetString(etatConnexion.buffer, 0, bytesRec);
                if (data.IndexOf("<EOF>") > -1)
                {
                    break;
                }
                else
                {
                    etatConnexion.chaineBuffer += data;
                }
            }
            return etatConnexion.chaineBuffer;
        }
    }
}
