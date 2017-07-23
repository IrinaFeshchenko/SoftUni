
namespace PlanetHunters.App
{
    using PlanetHunters.Data;

    class Program
    {
        static void Main()
        {
            var context = new PlanetHuntersContext();
            context.Database.Initialize(true);
        }
    }
}
