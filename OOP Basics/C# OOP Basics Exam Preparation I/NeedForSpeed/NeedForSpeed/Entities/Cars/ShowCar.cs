using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ShowCar:Car
{
    //o Has stars(int). (by default – 0)
    private int stars;

    public ShowCar(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability) 
        : base(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability)
    {
        this.Stars = 0;
    }

    public int Stars
    {
        get { return stars; }
        set { stars = value; }
    }

    public override string ToString()
    {
        //o	If the car is a ShowCar, you must print “{stars} *”, on the last line.
        StringBuilder sb = new StringBuilder(base.ToString());
        sb.AppendLine($"{this.Stars} *");
        return sb.ToString().Trim();
    }

    public override void Tune(int tuneIndex, string addOn)
    {
        this.stars += tuneIndex;
        base.Tune(tuneIndex, addOn);
    }
}
