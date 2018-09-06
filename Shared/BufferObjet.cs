using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Shared
{
    public class BufferObjet
    {
        public Socket socketConnexion = null;
        public const int tailleBuffer = 1024;
        public byte[] buffer = new byte[tailleBuffer];
        public String chaineBuffer;
    }
}