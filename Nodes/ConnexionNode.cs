using Shared;
using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Nodes
{
    public class ConnexionNode : IConnexionNode
    {

        private Socket socketNoeud;
        private static int tailleBuffer = 1024;
        private byte[] buffer = new byte[tailleBuffer];
        private StringBuilder stringBuffer = new StringBuilder();

        public ConnexionNode()
        {
            socketNoeud = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public String GetAdresse()
        {
            IPEndPoint ipPoint = socketNoeud.RemoteEndPoint as IPEndPoint;
            if (ipPoint != null)
            {
                return ipPoint.Address.ToString();
            }
            else
            {
                return null;
            }
        }

        public Socket GetSocket()
        {
            return socketNoeud;
        }

        public String GetPort()
        {
            IPEndPoint ipPoint = socketNoeud.RemoteEndPoint as IPEndPoint;
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
                socketNoeud.Connect(new IPEndPoint(ipServer.MapToIPv4(), 50000));
                return true;
            }
            return false;
        }

        private void OuvrirConnexionCallback(IAsyncResult resultat)
        {
            socketNoeud.EndConnect(resultat);
            Recevoir();
        }

        public Boolean FermerConnexion()
        {
            try
            {
                socketNoeud.Shutdown(SocketShutdown.Both);
                socketNoeud.Close();
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

        public String Recevoir()
        {

            BufferObjet etatConnexion = new BufferObjet();
            etatConnexion.socketConnexion = socketNoeud;
            String data = null;
            while (true)
            {
                int bytesRec = socketNoeud.Receive(etatConnexion.buffer);
                data = (String) Encoding.ASCII.GetString(etatConnexion.buffer, 0, bytesRec);
                if (data.Equals(String.Empty))
                {
                    break;
                }
                else
                {
                    etatConnexion.chaineBuffer += data;
                }
            }
            Console.WriteLine(etatConnexion.buffer);
            return etatConnexion.chaineBuffer;
        }

        public Boolean Envoyer(String donnees)
        {
            byte[] byteData = Encoding.ASCII.GetBytes(donnees);
            socketNoeud.Send(byteData);
            return true;
        }

        public ArrayList getConnexions()
        {
            throw new NotImplementedException();
        }

    }
}
