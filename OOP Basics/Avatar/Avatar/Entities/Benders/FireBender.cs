using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class FireBender: Bender
{
    //The FireBender has an additional characteristic:
    //•	HeatAggression – a floating-point number, holding the heatAggression of the Bender.
    private double heatAggression;

    public FireBender(string name, int power, double heatAggression) : base(power, name)
    {
        this.HeatAggression = heatAggression;
    }

    public double HeatAggression
    {
        get { return heatAggression; }
        set { heatAggression = value; }
    }

    public override double GetPower()
    {
        return this.heatAggression * this.Power;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Heat Aggression: {this.heatAggression:f2}";
    }
}
