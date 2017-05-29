
namespace MassDefect.Export
{
    using Data;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;

    class Startup
    {
        static void Main()
        {
            var context = new MassDefectContext();
            ExportPlanetsWhichAreNotAnomalyOrigins(context);
            //ExportPeopleWhichHaveNotBeenVictims(context);
            //ExportTopAnomaly();
        }

        private static void ExportTopAnomaly()
        {
            throw new NotImplementedException();
        }

        private static void ExportPeopleWhichHaveNotBeenVictims(MassDefectContext context)
        {
            var persons = context.Persons.Where(p => !p.Anomalies.Any())
                .Select(p => new
                {
                    name = p.Name,
                    homePlamen = p.HomePlanet.Name
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
