using System;
using System.Net.Sockets;
public interface IConnexionNode
{

    String GetAdresse();
    String GetPort();
    Boolean OuvrirConnexion();
    Boolean FermerConnexion();
    Boolean VerifierConnexion();
    Socket GetSocket();
    String Recevoir();
    Boolean Envoyer(String data);
}