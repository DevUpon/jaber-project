using System;
using System.Net;
using System.Net.Sockets;
using System.Collections;
public interface IConnexionOrchestrateur
{

    String GetAdresse();
    String GetPort();
    Boolean OuvrirConnexion();
    Boolean FermerConnexion();
    Boolean VerifierConnexion();
    Socket GetSocket(Socket handler);
    String Recevoir();
    Boolean Envoyer(String data);
}