using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class WaterBender:Bender
{
    //The WaterBender has an additional characteristic:
    //•	WaterClarity – a floating-point number, holding the waterClarity of the Bender.
    private double waterClarity;

    public WaterBender(string name, int power, double waterClarity) : base(power, name)
    {
        this.WaterClarity = waterClarity;
    }

    public double WaterClarity
    {
        get { return waterClarity; }
        set { waterClarity = value; }
    }

    public override double GetPower()
    {
        return this.waterClarity * this.Power;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Water Clarity: {this.WaterClarity:f2}";
    }
}
