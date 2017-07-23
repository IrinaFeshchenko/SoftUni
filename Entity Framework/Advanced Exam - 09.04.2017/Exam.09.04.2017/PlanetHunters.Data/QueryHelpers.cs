namespace PlanetHunters.Data
{
    using Dto;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class QueryHelpers
    {
        public static void ImportAstronomers(ICollection<AstronomerDTO> astronomers)
        {
            using (var context = new PlanetHuntersContext())
            {
                foreach (var astronomer in astronomers)
                {
                    if (astronomer.FirstName == null || astronomer.LastName == null)
                    {
                        Console.WriteLine("Invalid data format.");
                        continue;
                    }

                    Astronomer astronomerEntity = new Astronomer()
                    {
                        FirstName = astronomer.FirstName,
                        LastName = astronomer.LastName
                    };

                    context.Astronomers.Add(astronomerEntity);
                    Console.WriteLine($"Successfully imported {nameof(astronomerEntity)} {astronomerEntity.FirstName}.");
                }

                context.SaveChanges();
            }
        }


        public static void ImportTelescopes(ICollection<TelescopeDTO> telescopes)
        {
            using (var context = new PlanetHuntersContext())
            {
                foreach (var telescope in telescopes)
                {
                    if (telescope.Name == null || telescope.Location == null)
                    {
                        Console.WriteLine("Invalid data format.");
                        continue;
                    }

                    Telescope telescopeEntity = new Telescope()
                    {
                        Name = telescope.Name,
                        Location = telescope.Location,
                    };

                    if (telescope.MirrorDiameter != null && telescope.MirrorDiameter > 0m)
                    {
                        telescopeEntity.MirrorDiameter = telescope.MirrorDiameter;
                    }

                    context.Telescopes.Add(telescopeEntity);
                    Console.WriteLine($"Successfully imported {nameof(telescopeEntity)} {telescopeEntity.Name}.");
                }

                context.SaveChanges();
            }
        }

        public static void ImportDiscoveries(ICollection<DiscoveryDTO> discoveries)
        {
            using (var context = new PlanetHuntersContext())
            {
                foreach (var ds in discoveries)
                {
                    if (ds.DateMade == null || ds.Telescope == null ||
                        (ds.Observers == null && ds.Pioneers == null) ||
                        ds.Planets == null || ds.Stars == null)
                    {
                        Console.WriteLine("Invalid data format.");
                        continue;
                    }

                    if (!(AnyAstr(ds.Observers) || AnyAstr(ds.Pioneers)) )
                    {
                        Console.WriteLine("entity not found 1");
                        continue;
                    }
                    if (!( AnyPlanets(ds.Planets) || AnyStars(ds.Stars)))
                    {
                        Console.WriteLine("entity not found 2");
                        continue;
                    }

                    var observers = GetAst(ds.Observers);
                    var pioneers = GetAst(ds.Pioneers);
                    Discovery discoveryEntity = new Discovery()
                    {
                        DateMade = DateTime.ParseExact(ds.DateMade, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                        TelescopeId = context.Telescopes.First(t=>t.Name == ds.Telescope).Id,
                        Planets = context.Planets.Where(p=> ds.Planets.Contains(p.Name)).ToList(),
                        Stars = context.Stars.Where(p => ds.Stars.Select(s=>s.Name).Contains(p.Name)).ToList(),
                        Observers = observers,
                        Pioneers = pioneers
                    };

                    context.Didscoveries.Add(discoveryEntity);
                    Console.WriteLine($"Successfully imported {nameof(discoveryEntity)} {discoveryEntity.Telescope}.");
                }

                context.SaveChanges();
            }
        }

        private static ICollection<Astronomer> GetAst(IEnumerable<string> observers)
        {
            if (observers == null)
            {
                return null;
            }
            var context = new PlanetHuntersContext();
            var obs = new List<Astronomer>();

            foreach (var o in observers)
            {
                string[] names = o.Split(',');

                obs.Add(context.Astronomers.FirstOrDefault(a=>a.FirstName == names[0] && a.LastName == names[1]));
            }

            return obs;
        }

        private static bool AnyStars(IEnumerable<c> stars)
        {
            var context = new PlanetHuntersContext();

            foreach (var s in stars)
            {
                if (!context.Stars.Any(x => x.Name == s.Name))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool AnyPlanets(IEnumerable<string> planets)
        {
            var context = new PlanetHuntersContext();

            foreach (var p in planets)
            {
                if (!context.Planets.Any(x => x.Name == p))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool AnyAstr(IEnumerable<string> observers)
        {
            if (observers == null)
            {
                return false;
            }
            var context = new PlanetHuntersContext();

            foreach (var o in observers)
            {
                string[] names = o.Split(',');
                string fName = names[0];
                string lName = names[1];
                if (names.Length<2)
                {
                    return false;
                }
                if (!context.Astronomers.Any(a=>a.FirstName == fName && 
                                    a.LastName == lName))
                {
                    return false;
                }
            }

            return true;
        }

        public static void ImportStars(List<StarDTO> stars)
        {
            using (var context = new PlanetHuntersContext())
            {
                foreach (var star in stars)
                {
                    if (star.Name == null || star.Temperature == null || star.StarSystem == null || int.Parse(star.Temperature) < 2400)
                    {
                        Console.WriteLine("Invalid data format.");
                        continue;
                    }

                    if (!context.StarSystems.Any(s => s.Name == star.StarSystem))
                    {
                        StarSystem starSystemEntity = new StarSystem()
                        {
                            Name = star.StarSystem,
                        };
                        context.StarSystems.Add(starSystemEntity);
                    }

                    context.SaveChanges();

                    Star starEntity = new Star()
                    {
                        Name = star.Name,
                        Temperature = int.Parse(star.Temperature),
                        StarSystem = context.StarSystems.First(s => s.Name == star.StarSystem)
                    };

                    context.Stars.Add(starEntity);
                    Console.WriteLine($"Successfully imported {nameof(starEntity)} {starEntity.Name}.");
                }

                context.SaveChanges();
            }
        }

        public static void ImportPlanets(ICollection<PlanetDTO> planets)
        {
            using (var context = new PlanetHuntersContext())
            {
                foreach (var planet in planets)
                {
                    if (planet.Name == null || planet.Mass == null || planet.StarSystem == null || decimal.Parse(planet.Mass) <= 0m)
                    {
                        Console.WriteLine("Invalid data format.");
                        continue;
                    }

                    if (!context.StarSystems.Any(s => s.Name == planet.StarSystem))
                    {
                        StarSystem starSystemEntity = new StarSystem()
                        {
                            Name = planet.StarSystem,
                        };
                        context.StarSystems.Add(starSystemEntity);
                    }

                    context.SaveChanges();

                    Planet planetEntity = new Planet()
                    {
                        Name = planet.Name,
                        Mass = decimal.Parse(planet.Mass),
                        StarSystem = context.StarSystems.First(s => s.Name == planet.StarSystem)
                    };

                    context.Planets.Add(planetEntity);
                    Console.WriteLine($"Successfully imported {nameof(planetEntity)} {planetEntity.Name}.");
                }

                context.SaveChanges();
            }
        }
    }
}
