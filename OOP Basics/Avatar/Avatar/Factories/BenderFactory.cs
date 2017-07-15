using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class BenderFactory
{
    public static Bender MakeBender(List<string> benderArgs)
    {
        string benderType = benderArgs[0];
        string benderName = benderArgs[1];
        int benderPower = int.Parse(benderArgs[2]);
        double benderAuxParam = double.Parse(benderArgs[3]);

        //The type will either be “Air”, “Water”, “Fire” or “Earth”.
        if (benderType == "Air")
        {
            return new AirBender(benderName,benderPower,benderAuxParam);
        }
        else if (benderType == "Water")
        {
            return new WaterBender(benderName, benderPower, benderAuxParam);
        }
        else if (benderType == "Fire")
        {
            return new FireBender(benderName, benderPower, benderAuxParam);
        }
        else if (benderType == "Earth")
        {
            return new EarthBender(benderName, benderPower, benderAuxParam);
        }
        return null;
    }
}
