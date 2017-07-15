using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class WaterMonument:Monument
{
    //•	WaterAffinity – an integer, holding the waterAffinity of the Monument.
    private int waterAffinity;

    public WaterMonument(string name, int waterAffinity) : base(name)
    {
        this.WaterAffinity = waterAffinity;
    }

    public int WaterAffinity
    {
        get { return waterAffinity; }
        set { waterAffinity = value; }
    }

    public override int GetAffinity()
    {
        return this.waterAffinity;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Water Affinity: {WaterAffinity}";
    }
}
