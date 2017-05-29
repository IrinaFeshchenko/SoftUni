
namespace MassDefect.Import
{
    using System;
    using Data;
    using System.IO;
    using Data.DTO;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using Models;
    using System.Linq;
    using System.Xml.Linq;

    class Startup
    {
        private const string SolarSystemPath = "../../../datasets/solar-systems.json";
        private const string StarsPath = "../../../datasets/stars.json";
        private const string PlanetsPath = "../../../datasets/planets.json";
        private const string PersonsPath = "../../../datasets/persons.json";
        private const string AnomaliesPath = "../../../datasets/anomalies.json";
        private const string AnomalyVictimsPath = "../../../datasets/anomaly-victims.json";
        private const string NewAnomaliesPath = "../../../datasets/new-anomalies.xml";

        static void Main()
        {
            var context = new MassDefectContext();
            //ImportSolarSystems(context); Console.WriteLine();
            //ImportStars(context); Console.WriteLine();
            //ImportPlanets(context); Console.WriteLine();
            //ImportPersons(context); Console.WriteLine();
            //ImportAnomalies(context); Console.WriteLine();
            //ImportAnomalyVictims(context);
            ImportNewAnomalies(context);
        }

        private static void ImportNewAnomalies(MassDefectContext context)
        {
            XDocument text = XDocument.Load(NewAnomaliesPath);

            var newAnomalies = text.Root.Elements()
                .Select(anomaly => new NewAnomaliesDTO()
                {
                    OriginPlanet = anomaly.Attribute("origin-planet")?.Value,
                    TeleportPlanet = anomaly.Attribute("teleport-planet")?.Value,
                    Victims = anomaly.Element("victims").Elements().Select(e => e.Attribute("name")?.Value).ToList()
                });

            foreach (var a in newAnomalies)
            {
                var originPlanet = context.Planets.FirstOrDefault(p => p.Name == a.OriginPlanet);
                var teleportPlanet = context.Planets.FirstOrDefault(p => p.Name == a.TeleportPlanet);
                var persons = context.Persons.Where(p => a.Victims.Contains(p.Name)).ToList();

                if (originPlanet==null|| teleportPlanet==null||persons==null)
                {
                    Console.WriteLine($"Error: Invalid data.");
                    continue;
                }

                var anomaly = new Anomaly()
                {
                    OriginPlanet = originPlanet,
                    TeleportPlanet = teleportPlanet,
                    Persons = persons
                };

                context.Anomalies.Add(anomaly);
                Console.WriteLine("ok");
            }

            context.SaveChanges();
        }

        private static void ImportAnomalyVictims(MassDefectContext context)
        {
            var text = File.ReadAllText(AnomalyVictimsPath);

            var anomalyVictims = JsonConvert.DeserializeObject<ICollection<AnomalyVictimsDTO>>(text);

            foreach (var anomalyVictim in anomalyVictims)
            {
                var anomaly = context.Anomalies.FirstOrDefault(x => x.Id == anomalyVictim.Id);

                var victim = context.Persons.FirstOrDefault(x => x.Name == anomalyVictim.Person);
                if (anomaly == null || victim == null)
                {
                    Console.WriteLine($"Error: Invalid data.");
                    continue;
                }

                anomaly.Persons.Add(victim);
                Console.WriteLine("imported victim");
            }

            context.SaveChanges();
        }

        private static void ImportAnomalies(MassDefectContext context)
        {
            var text = File.ReadAllText(AnomaliesPath);

            var anomalies = JsonConvert.DeserializeObject<ICollection<AnomalyDTO>>(text);

            foreach (var a in anomalies)
            {
                var originPlanet = context.Planets.FirstOrDefault(x => x.Name == a.OriginPlanet);

                var teleportPlanet = context.Planets.FirstOrDefault(x => x.Name == a.TeleportPlanet);

                if (originPlanet == null || teleportPlanet == null)
                {
                    Console.WriteLine($"Error: Invalid data.");
                    continue;
                }

                Anomaly anomaly = new Anomaly()
                {
                    OriginPlanetId = originPlanet.Id,
                    
                    TeleportPlanetId = teleportPlanet.Id,
                };

                context.Anomalies.Add(anomaly);
                Console.WriteLine("Successfully imported anomaly.");
            }

            context.SaveChanges();
        }

        private static void ImportPersons(MassDefectContext context)
        {
            var text = File.ReadAllText(PersonsPath);

            var persons = JsonConvert.DeserializeObject<ICollection<PersonDTO>>(text);

            foreach (var person in persons)
            {
                var homePlanet = context.Planets.FirstOrDefault(p => p.Name == person.HomePlanet);

                if (person.Name == null || person.HomePlanet == null || homePlanet == null)
                {
                    Console.WriteLine($"Error: Invalid data.");
                    continue;
                }

                Person pesonEntity = new Person()
                {
                    Name = person.Name,
                    HomePlanetId = homePlanet.Id
                };

                context.Persons.Add(pesonEntity);
                Console.WriteLine($"Successfully imported {nameof(Person)} {person.Name}.");
            }

            context.SaveChanges();
        }

        private static void ImportPlanets(MassDefectContext context)
        {
            var text = File.ReadAllText(PlanetsPath);

            var planets = JsonConvert.DeserializeObject<ICollection<PlanetDTO>>(text);

            foreach (var planet in planets)
            {

                var solarSystem = context.SolarSystems.FirstOrDefault(x => x.Name == planet.SolarSystem);
                var sun = context.Stars.FirstOrDefault(x => x.Name == planet.Sun);

                if (planet.Name == null || planet.SolarSystem == null || planet.Sun == null ||
                    solarSystem == null || sun == null)
                {
                    Console.WriteLine($"Error: Invalid data.");
                    continue;
                }

                Planet planetEntity = new Planet()
                {
                    Name = planet.Name,
                    SolarSystemId = solarSystem.Id,
                    SunId = sun.Id
                };

                context.Planets.Add(planetEntity);
                Console.WriteLine($"Successfully imported {nameof(Planet)} {planet.Name}.");
            }

            context.SaveChanges();
        }

        private static void ImportStars(MassDefectContext context)
        {
            var text = File.ReadAllText(StarsPath);

            var stars = JsonConvert.DeserializeObject<ICollection<StarDTO>>(text);

            foreach (var star in stars)
            {
                var solarSystem = context.SolarSystems.FirstOrDefault(x => x.Name == star.SolarSystem);

                if (star.Name==null || star.SolarSystem ==null || solarSystem == null)
                {
                    Console.WriteLine($"Error: Invalid data.");
                    continue;
                }

                Star starEntity = new Star()
                {
                    Name = star.Name,
                    SolarSystemId = solarSystem.Id
                };

                context.Stars.Add(starEntity);
                Console.WriteLine($"Successfully imported {nameof(Star)} {star.Name}.");
            }

            context.SaveChanges();
        }

        private static void ImportSolarSystems(MassDefectContext context)
        {
            var text = File.ReadAllText(SolarSystemPath);

            var solarSystems = JsonConvert.DeserializeObject<ICollection<SolarSystemDTO>>(text);

            foreach (var solarSystem in solarSystems)
            {
                if (solarSystem.Name == null)
                {
                    Console.WriteLine($"Error: Invalid data.");
                    continue;
                }

                SolarSystem solarSystemEntity = new SolarSystem()
                {
                    Name = solarSystem.Name
                };

                context.SolarSystems.Add(solarSystemEntity);
                Console.WriteLine($"Successfully imported {nameof(SolarSystem)} {solarSystem.Name}.");
            }

            context.SaveChanges();
        }
    }
}
