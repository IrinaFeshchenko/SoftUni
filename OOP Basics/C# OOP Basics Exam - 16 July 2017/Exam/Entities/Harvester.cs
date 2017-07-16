using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Harvester:DraftObject
{
    //•	oreOutput - a floating-point number.
    private double oreOutput;
    //•	energyRequirement - a floating-point number.
    private double energyRequirement;
    
    protected Harvester(string id, double oreOutput, double energyRequirement)
        :base(id)
    {
        this.Id = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public double OreOutput
    {
        get { return oreOutput; }
        protected set
        {
            if (value<0)
            {
                throw new ArgumentException("OreOutput");
            }
            oreOutput = value;
        }
    }

    public double EnergyRequirement
    {
        get { return energyRequirement; }
        protected set
        {
            if (value < 0 || value > Constants.HARVESTER_MAX_ENERGY_REQUIREMENT)
            {
                throw new ArgumentException("EnergyRequirement");
            }
            energyRequirement = value;
        }
    }

    public override string ToString()
    {
        string type = this.GetType().Name;
        int typeIndex = type.IndexOf("Harvester");
        type = type.Remove(typeIndex);

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{type} Harvester - {this.Id}")
          .AppendLine($"Ore Output: {this.OreOutput}")
          .AppendLine($"Energy Requirement: {this.EnergyRequirement}");

        return sb.ToString().Trim();
    }
}
