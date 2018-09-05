using System;
using System.Net;
using System.Net.Sockets;
public interface IConnexionSocket
{

    String getAdresse();
    String getPort();
    Boolean ouvrirConnexion();
    Boolean fermerConnexion();
    Boolean verifierConnexion();
    Socket getSocket();
    String recevoir();
    Boolean envoyer(String data);
}
