
namespace MassDefect.Export
{
    using Data;
    using Newtonsoft.Json;
    using System.IO;
    using System.Linq;
    using System;

    class Startup
    {
        static void Main()
        {
            var context = new MassDefectContext();
            ExportPlanetsWhichAreNotAnomalyOrigins(context);
            ExportPeopleWhichHaveNotBeenVictims(context);
            ExportTopAnomaly(context);
            ExportAllAnomaliesAndPeople(context);
        }

        private static void ExportAllAnomaliesAndPeople(MassDefectContext context)
        {
            var anomalies = context.Anomalies.Select(a=> new
            {
                
            }).ToList();
        }

        private static void ExportTopAnomaly(MassDefectContext context)
        {
            var anomaly = context.Anomalies.OrderByDescending(a => a.Persons.Count())
                .Take(1)
                .Select(a => new
                {
                    id = a.Id,
                    originPlanet = new { name = a.OriginPlanet.Name },
                    teleportPlanet = new { name = a.TeleportPlanet.Name },
                    victimsCount = a.Persons.Count
                }).ToList();

            var text = JsonConvert.SerializeObject(anomaly, Formatting.Indented);
            File.WriteAllText("../../export/anomaly.json", text);
        }

        private static void ExportPeopleWhichHaveNotBeenVictims(MassDefectContext context)
        {
            var persons = context.Persons.Where(p => !p.Anomalies.Any())
                .Select(p => new
                {
                    name = p.Name,
                    homePlanet = new { name = p.HomePlanet.Name }
                }).ToList();

            var text = JsonConvert.SerializeObject(persons, Formatting.Indented);
            File.WriteAllText("../../export/persons.json", text);
        }

        private static void ExportPlanetsWhichAreNotAnomalyOrigins(MassDefectContext context)
        {
            var planets = context.Planets.Where(p => !p.OriginalAnomalies.Any())
                .Select(p => new
                {
                    name = p.Name
                }).ToList();

            var text = JsonConvert.SerializeObject(planets, Formatting.Indented);
            File.WriteAllText("../../export/planets.json", text);
        }
    }
}
