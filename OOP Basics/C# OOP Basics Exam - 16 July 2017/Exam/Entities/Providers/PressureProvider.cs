using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class PressureProvider : Provider
{
    public PressureProvider(string id, double energyOutput) : base(id, energyOutput)
    {
        //UPON INITIALIZATION, increases its energyOutput by 50 %.
        base.EnergyOutput += base.EnergyOutput / 2;
    }
}
