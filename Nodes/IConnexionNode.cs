using System;
using System.Net;
using System.Net.Sockets;
using System.Collections;
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