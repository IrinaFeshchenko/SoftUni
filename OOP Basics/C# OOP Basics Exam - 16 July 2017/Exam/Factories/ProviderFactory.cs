using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class ProviderFactory
{
    public static Provider MakeProvider(List<string> args)
    {
        string type = args[0];
        string id = args[1];
        double energyOutput = double.Parse(args[2]);
        //use switch instead if?
        if (type == "Solar")
        {
            return new SolarProvider(id,energyOutput);
        }
        else if (type == "Pressure")
        {
            return new PressureProvider(id,energyOutput);
        }

        throw new ArgumentException("wrong harvester type");
    }
}
