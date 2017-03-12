using _5.Photographers.Data;
using System.Linq;

namespace _5.Photographers
{
    class Startup
    {
        static void Main()
        {
            var context = new PhotographerContext();
            System.Console.WriteLine(context.Photographers.Count());
        }
    }
}
