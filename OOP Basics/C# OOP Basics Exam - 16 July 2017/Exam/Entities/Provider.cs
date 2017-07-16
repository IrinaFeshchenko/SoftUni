using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Provider:DraftObject
{
    //•	energyOutput - a floating-point number.
    private double energyOutput;

    protected Provider(string id, double energyOutput)
        :base(id)
    {
        this.EnergyOutput = energyOutput;
    }

    public double EnergyOutput
    {
        get { return energyOutput; }
        protected set
        {
            if (value<0||value>=Constants.PROVIDER_MAX_ENERGY_OUTPUT)
            {
                throw new ArgumentException("EnergyOutput");
            }
            energyOutput = value;
        }
    }

    public override string ToString()
    {
        string type = this.GetType().Name;
        int typeIndex = type.IndexOf("Provider");
        type = type.Remove(typeIndex);

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{type} Provider - {this.Id}")
          .AppendLine($"Energy Output: {this.EnergyOutput}");

        return sb.ToString().Trim();
    }
}
