using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class HammerHarvester : Harvester
{
    public HammerHarvester(string id, double oreOutput, double energyRequirement) : base(id, oreOutput, energyRequirement)
    {
        //UPON INITIALIZATION, increases its oreOutput by 200 %
        base.OreOutput += base.OreOutput*2;

        //and increases its energyRequirement by 100%
        base.EnergyRequirement += base.EnergyRequirement;
    }
}
