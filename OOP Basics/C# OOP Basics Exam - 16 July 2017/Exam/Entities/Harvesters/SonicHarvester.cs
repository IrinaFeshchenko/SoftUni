using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SonicHarvester : Harvester
{
    //•	sonicFactor - an integer.
    private int sonicFactor;

    public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor)
        : base(id, oreOutput, energyRequirement)
    {
        this.SonicFactor = sonicFactor;
        //UPON INITIALIZATION, divides its given energyRequirement by its sonicFactor.
        base.EnergyRequirement /= this.SonicFactor;
        //todo: base check initialise before ctor?
    }
    public int SonicFactor 
    {
        get { return sonicFactor; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("SonicFactor");
            }
            sonicFactor = value;
        }
    }
}
