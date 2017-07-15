using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class EarthMonument:Monument
{
    //•	EarthAffinity – an integer, holding the earthAffinity of the Monument.
    private int earthAffinity;

    public EarthMonument(string name, int earthAffinit) : base(name)
    {
        this.EarthAffinity = earthAffinit;
    }

    public int EarthAffinity
    {
        get { return earthAffinity; }
        set { earthAffinity = value; }
    }

    public override int GetAffinity()
    {
        return this.EarthAffinity;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Earth Affinity: {this.EarthAffinity}";
    }
}
