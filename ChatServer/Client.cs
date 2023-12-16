using System;
using System.Net;
using System.Net.Sockets;

namespace ChatServer
{
    class Client
    {
        public string Username { get; set; }
        public Guid UID { get; set; }
        public TcpClient ClientSocket { get; set; }

        public Client(TcpClient client) {
            ClientSocket = client;
            UID = Guid.NewGuid();

            Console.WriteLine($"[{DateTime.Now}]:Client has connected with the username: {Username}");
            
        }
    }
}
