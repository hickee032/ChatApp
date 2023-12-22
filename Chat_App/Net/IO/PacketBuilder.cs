﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_App.Net.IO
{
    class PacketBuilder
    {
        MemoryStream _ms;
        public PacketBuilder() {
            _ms= new MemoryStream();
        }

        public void WriteOpCode(byte opcode) {
            _ms.WriteByte(opcode);
        }

        public void WriteMessage(string msg) {
            byte[] buff = BitConverter.GetBytes(msg.Length);
            _ms.Write(buff, 0, buff.Length); 
            _ms.Write(Encoding.ASCII.GetBytes(msg), 0, msg.Length);
        }

        public byte[] GetPacketBytes() {
            return _ms.ToArray();
        }
    }
}
