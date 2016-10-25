namespace CubicAssault
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Meteor
    {
        public string Type { get; set; }
        public int count { get; set; }
    }
    public class Region
    {
        Dictionary<string, long> meteors;

        public Region()
        {
            this.meteors = new Dictionary<string, long>();
            meteors.Add("Red",0);
            meteors.Add("Black", 0);
            meteors.Add("Green", 0);
        }
        Meteor[] meteors = new Meteor[3];

        public void Update(Region region)
        {
            this.meteors[region.] += region.Red;
            this.Green += region.Green;
            this.Black += region.Black;
        }
    }

    public class Program
    {
        public static void Main()
        {
            Dictionary<string, Region> regions = new Dictionary<string, Region>();
            string message;

            while ((message = Console.ReadLine()) == "Count em all")
            {
                string[] args = message.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Region region = new Region();
                region.Name = args[0];
                string type = args[1];
                int count = int.Parse(args[2]);

                if (type == "Red")
                {
                    region. += count;
                }
                else if (type == "Green")
                {
                    region.Green += count;
                }
                else if (type == "Black")
                {
                    region.Black += count;
                }

                if (!regions.ContainsKey(region.Name))
                {
                    regions.Add(region.Name,region);
                }
                else
                {
                    regions[region.Name].Update(region);
                }
            }

            var orderedRegions = regions.OrderByDescending(x=>x.Value.Black)
                                        .ThenBy(x=>x.Key.Length)
                                        .ThenBy(x=>x.Key);

        }
    }
}
