using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TimeClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            int port = 1010;

            Socket client = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp);

            try
            {
                client.Connect(new IPEndPoint(ip, port));

                Console.WriteLine("1 - Дата");
                Console.WriteLine("2 - Час");

                string request = Console.ReadLine() == "1"
                    ? "date"
                    : "time";

                client.Send(Encoding.UTF8.GetBytes(request));

                byte[] buffer = new byte[1024];

                int bytesReceived = client.Receive(buffer);

                string response =
                    Encoding.UTF8.GetString(buffer, 0, bytesReceived);

                Console.WriteLine("Відповідь сервера:");
                Console.WriteLine(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                client.Close();
            }
        }
    }
}