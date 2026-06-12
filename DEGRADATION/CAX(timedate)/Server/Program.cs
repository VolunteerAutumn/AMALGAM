using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TimeServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            int port = 1010;

            Socket server = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp);

            server.Bind(new IPEndPoint(ip, port));
            server.Listen(10);

            Console.WriteLine("Server running...");

            while (true)
            {
                Socket client = server.Accept();

                byte[] buffer = new byte[1024];

                int bytesReceived = client.Receive(buffer);

                string request =
                    Encoding.UTF8.GetString(buffer, 0, bytesReceived);

                string response;

                if (request.ToLower() == "time")
                {
                    response = DateTime.Now.ToLongTimeString();
                }
                else if (request.ToLower() == "date")
                {
                    response = DateTime.Now.ToShortDateString();
                }
                else
                {
                    response = "Невідома команда";
                }

                client.Send(Encoding.UTF8.GetBytes(response));

                client.Close();
            }
        }
    }
}