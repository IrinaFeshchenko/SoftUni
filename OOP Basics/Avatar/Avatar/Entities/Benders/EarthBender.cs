using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class EarthBender:Bender
{
    //The EarthBender has an additional characteristic:
    //•	GroundSaturation – a floating-point number, holding the groundSaturation of the Bender.
    private double groundSaturation;

    public EarthBender(string name, int power, double groundSaturation) : base(power, name)
    {
        this.GroundSaturation = groundSaturation;
    }

    public double GroundSaturation
    {
        get { return groundSaturation; }
        set { groundSaturation = value; }
    }

    public override double GetPower()
    {
        return this.groundSaturation * this.Power;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Ground Saturation: {this.groundSaturation:f2}";
    }
}
