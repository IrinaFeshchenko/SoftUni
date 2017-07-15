using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class AirMonument:Monument
{
    //•	AirAffinity – an integer, holding the airAffinity of the Monument.
    private int airAffinity;

    public AirMonument(string name, int airAffinity) : base(name)
    {
        this.AirAffinity = airAffinity;
    }

    public int AirAffinity
    {
        get { return airAffinity; }
        set { airAffinity = value; }
    }
    public override int GetAffinity()
    {
        return this.airAffinity;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Air Affinity: {this.AirAffinity}";
    }
}
