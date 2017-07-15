using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class AirBender:Bender
{
    //  The AirBender has an additional characteristic:
    //•	AerialIntegrity – a floating-point number, holding the aerialIntegrity of the Bender.
    private double aerialIntegrity;

    public AirBender(string name, int power, double aerialIntegrity) : base(power, name)
    {
        this.AerialIntegrity = aerialIntegrity;
    }

    public double AerialIntegrity
    {
        get { return aerialIntegrity; }
        set { aerialIntegrity = value; }
    }

    public override double GetPower()
    {
        return this.aerialIntegrity * this.Power;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Aerial Integrity: {this.AerialIntegrity:f2}" ;
    }
}
