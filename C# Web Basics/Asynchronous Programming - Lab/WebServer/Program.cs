using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WebServer
{
    public class Program
    {
        public static void Main()
        {
            IPAddress address = IPAddress.Parse("127.0.0.1");
            int port = 1300;
            TcpListener listerer = new TcpListener(address,port);
            listerer.Start();

            Console.WriteLine($"Server started.");
            Console.WriteLine("Listening to TCP clients at 127.0.0.1:{port}");

            var task = Task.Run(() => ConnectWithTcpClient(listerer));
            task.Wait();
        }

        public static async Task ConnectWithTcpClient(TcpListener listener)
        {
            while (true)
            {
                Console.WriteLine("Waithing for client");
                var client = await listener.AcceptTcpClientAsync();

                // Read and print the request
                Console.WriteLine("Client connected.");
                byte[] buffer = new byte[1024];
                client.GetStream().Read(buffer, 0, buffer.Length);

                var message = Encoding.UTF8.GetString(buffer);
                Console.WriteLine(message);

                // Reply to the client
                byte[] data = Encoding.UTF8.GetBytes("HTTP/1.1 200 OK\n\nHello from server!");
                client.GetStream().Write(data, 0, data.Length);

                Console.WriteLine("Closing connection.");
                client.GetStream().Dispose();
            }
        }
    }
}
