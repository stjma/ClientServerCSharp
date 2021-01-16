using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientServerCSharp
{
    class Server
    {
        private string serverIp;
        private int serverPort;
        public Server(string serverIp, int serverPort)
        {
            this.serverIp = serverIp;
            this.serverPort = serverPort;
        }

        public void Run()
        {
            //socket creation
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(new IPEndPoint(IPAddress.Parse(serverIp),serverPort));
            //listen
            server.Listen(15);
            //Accept connection
            while (true)
            {
                Console.WriteLine("Connection wait");
                Socket communicationServer = server.Accept();
                Console.WriteLine(String.Format("connection is established {0}",((IPEndPoint)communicationServer.RemoteEndPoint).Address.ToString()));

                //Stream reader
                StreamReader streamReader = new StreamReader(new NetworkStream(communicationServer));
                string message;
                //COmmunication loop
                while((message=streamReader.ReadLine()) != null)
                {
                    Console.WriteLine(message);
                }

                //close
                communicationServer.Shutdown(SocketShutdown.Receive);
                communicationServer.Close();
            }
 
        }
    }
}
