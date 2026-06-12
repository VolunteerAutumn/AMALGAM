using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            int port = 1010;

            IPEndPoint endPoint = new IPEndPoint(ip, port);

            Socket server = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp);

            try
            {
                server.Bind(endPoint);
                server.Listen(10);

                Console.WriteLine("Server running...");

                Socket client = server.Accept();

                byte[] buffer = new byte[1024];

                int bytesReceived = client.Receive(buffer);

                string message =
                    Encoding.UTF8.GetString(buffer, 0, bytesReceived);

                Console.WriteLine(
                    $"О {DateTime.Now:HH:mm} від {client.RemoteEndPoint} отримано рядок: {message}");

                string response = "Привіт, клієнт!";

                client.Send(Encoding.UTF8.GetBytes(response));

                client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                server.Close();
            }
        }
    }
}