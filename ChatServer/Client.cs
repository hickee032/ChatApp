﻿using ChatrSever;
using ChatServer.Net.IO;
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
        PacketReader _packetReader;
        public Client(TcpClient client) {
            ClientSocket = client;
            UID = Guid.NewGuid();
            _packetReader = new PacketReader(ClientSocket.GetStream());

            var opcode = _packetReader.ReadByte();
            Username = _packetReader.ReadMessage();

            Console.WriteLine($"[{DateTime.Now}]:Client has connected with the username: {Username}");
            
        }

        void Process() {

            while (true) {

                try {
                    var opcode = _packetReader.ReadByte();
                    switch (opcode) {
                        case 5: {
                                var msg = _packetReader.ReadMessage();
                                Console.WriteLine($"[{DateTime.Now}]: Message Received!! {msg}");
                                Program.BroadcastMessage( msg );
                                break;
                            }
                        default: {
                                break;
                            }
                    }
                
                } 
                catch(Exception) {
                    Console.WriteLine($"[{UID.ToString()}]: Disconnected!");
                    ClientSocket.Close();
                    throw;
                
                }
            }
        }
    }
}
