using System;
using System.Collections.Generic;

namespace PlanetHunters.Dto
{
    public class c
    {
        public string Name;
        public string Temperature;
    }

    public class DiscoveryDTO
    {
        public DiscoveryDTO()
        {
            Stars = new List<c>();
            Planets = new List<string>();
            Pioneers = new List<string>();
            Observers = new List<string>();
        }

        public string DateMade { get; set; }

        public string Telescope { get; set; }

        public IEnumerable<c> Stars { get; set; }

        public IEnumerable<string> Planets { get; set; }

        public IEnumerable<string> Pioneers { get; set; }

        public IEnumerable<string> Observers { get; set; }

    }
}
