
namespace MassDefect.Data.DTO
{
    using System.Collections.Generic;

    public class NewAnomaliesDTO
    {
        public string OriginPlanet { get; set; }

        public string TeleportPlanet { get; set; }

        public ICollection<string> Victims { get; set; }
    }
}
