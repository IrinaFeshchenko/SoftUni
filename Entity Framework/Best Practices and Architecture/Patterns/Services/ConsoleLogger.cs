
namespace Patterns.Services
{
    using System;

    class ConsoleLogger : Logger
    {
        public override void Log(string line)
        {
            Console.WriteLine(line);
        }
    }
}
