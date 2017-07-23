
namespace PlanetHunters.Import
{
    using Data;
    using Dto;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    class Program
    {
        private const string AstronomersPath = "../../../datasets/astronomers.json";
        private const string TelescopesPath = "../../../datasets/telescopes.json";
        private const string PlanetsPath = "../../../datasets/planets.json";
        private const string StarsPath = "../../../datasets/stars.xml";
        private const string DiscoveriesPath = "../../../datasets/discoveries.xml";

        static void Main()
        {
            //JSON
            //ImportAstronomers();
            //ImportTelescopes();h
            //ImportPlanets();
            //XML
            //ImportStars();
            ImportDiscoveries();

        }

        private static void ImportDiscoveries()
        {
            XDocument text = XDocument.Load(DiscoveriesPath);
            ICollection<DiscoveryDTO> dtos = new List<DiscoveryDTO>();

            var discoveries = text.Root.Elements().Select(d => new
            DiscoveryDTO
            {
                DateMade = d.Attribute("DateMade").Value,
                Telescope = d.Attribute("Telescope").Value,
                Stars = d.Element("Stars").Elements("Star")?.Select(s=>new c
                {
                    Name = s.Value,
                    Temperature = s.Attribute("Temperature")?.Value
                }),
                Pioneers = d.Element("Pioneers").Elements()?.Select(a=>a.Value),
                Observers = d.Element("Observes")?.Elements()?.Select(o=>o.Value),
                Planets = d.Element("Planets").Elements()?.Select(p=>p.Value)
            }).ToList();

            QueryHelpers.ImportDiscoveries(discoveries);
        }

        private static void ImportStars()
        {
            XDocument text = XDocument.Load(StarsPath);

            var stars = text.Root.Elements().Select(u => new StarDTO()
            {
                Name = u.Element("Name")?.Value,
                Temperature = u.Element("Temperature")?.Value,
                StarSystem = u.Element("StarSystem")?.Value
            }).ToList();

            QueryHelpers.ImportStars(stars);
        }

        private static void ImportPlanets()
        {
            var text = File.ReadAllText(PlanetsPath);

            var planets = JsonConvert.DeserializeObject<ICollection<PlanetDTO>>(text);

            QueryHelpers.ImportPlanets(planets);
        }

        private static void ImportTelescopes()
        {
            var text = File.ReadAllText(TelescopesPath);

            var telescopes = JsonConvert.DeserializeObject<ICollection<TelescopeDTO>>(text);

            QueryHelpers.ImportTelescopes(telescopes);
        }

        private static void ImportAstronomers()
        {
            var text = File.ReadAllText(AstronomersPath);

            var astronomers = JsonConvert.DeserializeObject<ICollection<AstronomerDTO>>(text);

            QueryHelpers.ImportAstronomers(astronomers);
        }
    }
}
