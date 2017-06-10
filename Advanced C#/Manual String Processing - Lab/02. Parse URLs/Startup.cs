namespace _02.Parse_URLs
{
    using System;
    using System.Linq;

    public class Startup
    {
        static void Main()
        {
            try
            {
                var input = Console.ReadLine();
                HtmlParser parser = new HtmlParser(input);

                Console.WriteLine($"Protocol = {parser.Protocol}");
                Console.WriteLine($"Server = {parser.Server}");
                Console.WriteLine($"Resources = {parser.Resources}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    public class HtmlParser
    {
        private string input;
        private string protocolSeparator = "://";
        private string resourceSeparator = "/";

        public HtmlParser(string input)
        {
            this.Input = input;
            Parse(Input);
        }

        public string Input
        {
            get { return input; }
            set
            {
                string[] tokens = value.Split(new[] { protocolSeparator }, StringSplitOptions.RemoveEmptyEntries);

                if ((tokens.Count() !=2) ||
                   (tokens[1].IndexOf(resourceSeparator) == -1))
                {
                    throw new ArgumentException("Invalid URL");
                }

                input = value;
            }
        }

        public string Protocol { get; set; }
        public string Server { get; set; }
        public string Resources { get; set; }

        private void Parse(string input)
        {
            string[] args = input.Split(new[] { protocolSeparator }, StringSplitOptions.RemoveEmptyEntries);

            // parse protocol
            Protocol = args[0];

            // parse server
            int serverNameLength = args[1].IndexOf(resourceSeparator);
            Server = args[1].Substring(0, serverNameLength);

            // parse resources
            int resourcesStartIndex = serverNameLength + 1;
            int resourcesTextLength = args[1].Length - resourcesStartIndex;
            Resources = args[1].Substring(resourcesStartIndex, resourcesTextLength);
        }
    }
}
