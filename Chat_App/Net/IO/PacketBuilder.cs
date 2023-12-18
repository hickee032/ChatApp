using System;
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
    }
}
