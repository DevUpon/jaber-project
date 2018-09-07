using System;
using System.Net.Sockets;
using System.Collections;
using System.Collections.Generic;

public interface IConnexionOrchestrateur
{

    String GetAdresse();
    String GetPort();
    Boolean OuvrirConnexion(int countNode);
    Boolean FermerConnexion();
    Boolean VerifierConnexion();
    Socket GetSocket();
    String Recevoir(Socket handler);
    Boolean Envoyer(List<List<String>> data);
    ArrayList GetConnexions();
}