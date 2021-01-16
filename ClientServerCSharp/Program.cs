using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientServerCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client("10.4.129.24", 1040, "10.4.129.25", 1045);
            Server server = new Server("10.4.129.24", 1045);


            new Thread(client.Run).Start();
            //new Thread(server.Run).Start();
        }
    }
}
