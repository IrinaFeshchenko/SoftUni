
namespace TeamBuilder.App
{
    using Core;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Application
    {
        static void Main()
        {
            Engine engine = new Engine(new CommandDispatcher());
            engine.Run();
        }
    }
}
