using System;
using System.Net;

namespace Validate_URL
{
    public class Program
    {
        public static void Main()
        {
            string url = Console.ReadLine();

            var decodedUrl = WebUtility.UrlDecode(url);

            Uri myUri = new Uri(decodedUrl);

            // Get the protocol
            string protocol = myUri.Scheme;
            // Get host 
            string host = myUri.Host;
            // Get port
            int port = myUri.Port;
            // Get path
            string path = myUri.AbsolutePath;
            // Get query
            string query = myUri.Query.TrimStart('?');
            // Get fragment
            string fragment = myUri.Fragment.TrimStart('#');

            if (string.IsNullOrWhiteSpace(protocol) ||
                string.IsNullOrWhiteSpace(host) ||
                (port == 0) ||
                string.IsNullOrWhiteSpace(path)||
                (protocol == "http" && port != 80))
            {
                Console.WriteLine("Invalid URL");
            }
            else
            {
                Console.WriteLine($"Protocol: {protocol}");
                Console.WriteLine($"Host: {host}");
                Console.WriteLine($"Port: {port}");
                Console.WriteLine($"Path: {path}");
                if (!string.IsNullOrWhiteSpace(query))
                {
                    Console.WriteLine($"Query: {query}");
                }
                if (!string.IsNullOrWhiteSpace(fragment))
                {
                    Console.WriteLine($"Fragment: {fragment}");
                }
            }

        }
    }
}
