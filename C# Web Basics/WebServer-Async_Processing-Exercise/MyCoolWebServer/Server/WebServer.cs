namespace MyCoolWebServer.Server
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading.Tasks;

    using MyCoolWebServer.Server.Contracts;
    using MyCoolWebServer.Server.Routing;
    using MyCoolWebServer.Server.Routing.Contracts;

    public class WebServer : IRunnable
    {
        private const string LocalHostIP = "127.0.0.1";
        private readonly int port;
        private readonly IServerRouteConfig serverRouteConfig;
        private readonly TcpListener listener;
        private bool isRunning;

        public WebServer(int port, IAppRouteConfig appRouteConfig)
        {
            this.port = port;
            this.serverRouteConfig = new ServerRouteConfig(appRouteConfig);
            this.listener = new TcpListener(IPAddress.Parse(LocalHostIP), port);
        }

        public void Run()
        {
            this.listener.Start();
            this.isRunning = true;

            Console.WriteLine($"Server running on {LocalHostIP}:{this.port}");

            Task.Run(this.ListenLoop).Wait();
        }

        private async Task ListenLoop()
        {
            while (this.isRunning)
            {
                var client = await this.listener.AcceptSocketAsync();
                var connectioHandler = new ConnectionHandler(client, this.serverRouteConfig);
                await connectioHandler.ProcesRequestAsync();
            }
        }
    }
}
