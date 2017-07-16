using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class HarvesterFactory
{
    public static Harvester MakeHarvester(List<string> args)
    {
        string type = args[0];
        string id = args[1];
        double oreOutput = double.Parse(args[2]);
        double energyRequirement = double.Parse(args[3]);

        if (type == "Sonic ")
        {
            int sonicFactor = int.Parse(args[4]);
            return new SonicHarvester(id, oreOutput, energyRequirement,sonicFactor);
        }
        else if (type == "Hammer")
        {
            return new HammerHarvester(id, oreOutput, energyRequirement);
        }
        
        throw new ArgumentException("wrong harvester type");
    }
}
