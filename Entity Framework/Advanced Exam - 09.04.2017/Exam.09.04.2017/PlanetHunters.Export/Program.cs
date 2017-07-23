
namespace PlanetHunters.Export
{
    using Data;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main()
        {
            PlanetsByTrapis("TRAPPIST");
            //AstronomersOfAC("Alpha Centauri");
            //ExportStars();
        }

        private static void ExportStars()
        {
            throw new NotImplementedException();
        }

        private static void AstronomersOfAC(string starSystem)
        {
            //var context = new PlanetHuntersContext();

            //var text = context.Astronomers.Where(a=>a.PioneerDiscoveries.Where(d=>d.Planets.Where(p=>p.StarSystem.Name == starSystem
            //|| d.Stars.Where(p=>p.StarSystem.Name == starSystem)
            //    .Select(p => new
            //    {
            //        //name = p.Name,
            //        //mass = p.Mass,
            //        //orbiting = p.StarSystem.Name
            //    }
            //    ).ToList();

            //var export = JsonConvert.SerializeObject(text, Formatting.Indented);

            //File.WriteAllText("../../../exports/planets-by-TRAPPIST.json", export);
        }

        private static void PlanetsByTrapis(string telescopeName)
        {
            var context = new PlanetHuntersContext();

            var text = context.Planets
                .Select( p=> new
                {
                    name = p.Name,
                    mass = p.Mass,
                    orbiting = p.Discovery.Stars
                }
                ).ToList();

            var export = JsonConvert.SerializeObject(text, Formatting.Indented);

            File.WriteAllText("../../../exports/planets-by-TRAPPIST.json", export);
        }
    }
}
