using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class MonumentFactory
{
    public static Monument MakeMonument(List<string> monumentArgs)
    {
        string monumentType = monumentArgs[0];
        string monumentName = monumentArgs[1];
        int monumentAffinity = int.Parse(monumentArgs[2]);

        //The type will either be “Air”, “Water”, “Fire” or “Earth”.
        if (monumentType == "Air")
        {
            return new AirMonument(monumentName, monumentAffinity);
        }
        else if (monumentType == "Water")
        {
            return new WaterMonument(monumentName, monumentAffinity);
        }
        else if (monumentType == "Fire")
        {
            return new FireMonument(monumentName, monumentAffinity);
        }
        else if (monumentType == "Earth")
        {
            return new EarthMonument(monumentName, monumentAffinity);
        }
        return null;
    }
}
