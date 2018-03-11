using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Client_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipServer = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);
            client.Connect(ipServer);
            string Gui = "Hello Server !!!!!";
            byte[] gui = Encoding.ASCII.GetBytes(Gui);
            client.Send(gui);
            byte[] nhan = new byte[1024 * 60];
            int rec = client.Receive(nhan);
            string Nhan = Encoding.ASCII.GetString(nhan, 0, rec);
            StreamWriter sw = new StreamWriter("..//..//TextFile1.txt");
            sw.Write(Nhan);
            sw.Close();
        }
    }
}
