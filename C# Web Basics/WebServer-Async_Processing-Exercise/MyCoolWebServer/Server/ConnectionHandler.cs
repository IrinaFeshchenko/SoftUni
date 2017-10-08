namespace MyCoolWebServer.Server
{
    using System;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;
    using MyCoolWebServer.Server.Handlers;
    using MyCoolWebServer.Server.Http;
    using MyCoolWebServer.Server.Http.Contracts;
    using MyCoolWebServer.Server.Routing.Contracts;
    using System.Linq;

    public class ConnectionHandler
    {

        private readonly IServerRouteConfig serverRouteConfig;
        private readonly Socket client;

        public ConnectionHandler(Socket client, IServerRouteConfig serverRouteConfig)
        {
            this.serverRouteConfig = serverRouteConfig;
            this.client = client;
        }

        public async Task ProcesRequestAsync()
        {
            var httpRequest = await this.ReadRequest();

            if (httpRequest != null)
            {
                var httpContext = new HttpContext(httpRequest);

                var httpResponse = new HttpHandler(this.serverRouteConfig).Handle(httpContext);

                var responseBytes = Encoding.UTF8.GetBytes(httpResponse.ToString());

                var byteSegments = new ArraySegment<byte>(responseBytes);

                await this.client.SendAsync(byteSegments, SocketFlags.None);

                Console.WriteLine($"----REQUEST-----");
                Console.WriteLine(httpRequest);
                Console.WriteLine("-----RESPONSE----");
                Console.WriteLine(httpResponse);
                Console.WriteLine();
            }

            this.client.Shutdown(SocketShutdown.Both);
        }

        private async Task<IHttpRequest> ReadRequest()
        {
            var result = new StringBuilder();
            var data = new ArraySegment<byte>(new byte[1024]);

            while (true)
            {
                int numberOfBytesRead = await this.client.ReceiveAsync(data, SocketFlags.None);

                if (numberOfBytesRead == 0)
                {
                    break;
                }

                var bytesAsString = Encoding.UTF8.GetString(data.Array, 0, numberOfBytesRead);
                result.Append(bytesAsString);

                if (numberOfBytesRead < 1024)
                {
                    break;
                }
            }

            if (result.Length == 0)
            {
                return null;
            }

            return new HttpRequest(result.ToString());
        }
    }
}
