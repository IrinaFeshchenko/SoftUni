using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class FireMonument:Monument
{
    //•	FireAffinity – an integer, holding the fireAffinity of the Monument.
    private int fireAffinity;

    public FireMonument(string name, int fireAffinity) : base(name)
    {
        this.FireAffinity = fireAffinity;
    }

    public int FireAffinity
    {
        get { return fireAffinity; }
        set { fireAffinity = value; }
    }

    public override int GetAffinity()
    {
        return this.fireAffinity;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Fire Affinity: {this.fireAffinity}";
    }
}
