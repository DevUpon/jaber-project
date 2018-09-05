using System;
using System.Net;
using System.Net.Sockets;
using System.Collections;
public interface IConnexionSocket
{

    String getAdresse();
    String getPort();
    Boolean ouvrirConnexion();
    Boolean fermerConnexion();
    Boolean verifierConnexion();
    ArrayList getConnexions();
    String recevoir(Socket handler);
    Boolean envoyer(String data);
}