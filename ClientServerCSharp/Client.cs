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
    class Client
    {
        private string clientIp;
        private int clientPort;

        private string serverIp;
        private int serverPort;

        public Client(String clientIp,int clientport,string serverIp, int serverPort)
        {
            this.clientIp = clientIp;
            this.clientPort = clientport;
            this.serverIp = serverIp;
            this.serverPort = serverPort;
        }

        public void Run()
        {
            Socket communicationSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            communicationSocket.Bind(new IPEndPoint(IPAddress.Parse(clientIp), clientPort));
            Console.WriteLine("j'ai fait une demande de connexion");
            communicationSocket.Connect(new IPEndPoint(IPAddress.Parse(serverIp), serverPort));
            Console.WriteLine("connect to server");

            StreamWriter streamWriter = new StreamWriter(new NetworkStream(communicationSocket));

            String message;
            while((message = Console.ReadLine()).Length != 0){
                streamWriter.WriteLine(message);
                streamWriter.Flush();
            }
            communicationSocket.Disconnect(false);
            communicationSocket.Close();
        }
    }
}
