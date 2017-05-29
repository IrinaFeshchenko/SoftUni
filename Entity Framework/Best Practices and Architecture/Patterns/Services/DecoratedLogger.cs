
namespace Patterns.Services
{
    using System;

    class DecoratedLogger : Logger
    {
        public override void Log(string line)
        {
            Console.WriteLine($"Action received {line}");
        }
    }
}
