using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class PerformanceCar:Car
{
    //o	Has addOns (Collection of strings). (by default – empty)
    private List<string> addOns;

    public PerformanceCar(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
        : base(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability)
    {
        this.ModifyStats();
        this.addOns = new List<string>();
    }

    public IReadOnlyList<string> AddOns
    {
        get => addOns.AsReadOnly();
    }

    //o	Increases its given horsepower by 50%.
    //o	Decreases its given suspension by 25%.
    public void ModifyStats()
    {
        this.Horsepower += this.Horsepower *
                           Constants.PERFOROMANCE_CAR_HOREPOWER_INCREASE_PERCENTAGE /
                           Constants.MAX_PERCENTAGE;
        this.Suspension -= this.Suspension *
                           Constants.PERFORMANCE_CAR_SUSPENSION_DECREASE_PERCENTAGE /
                           Constants.MAX_PERCENTAGE;
    }

    public override string ToString()
    {
        //o If the car is a PerformanceCar, you must print 
        //            “Add-ons: { add - ons}”, 
        //on the last line – each add-on separated by a comma and a space “, “. 
        //        In case there are NO add-ons, print “None”.

        StringBuilder sb = new StringBuilder(base.ToString());

        if (this.addOns.Any())
        {
            sb.AppendLine($"Add-ons: {string.Join(", ", this.AddOns)}");
        }
        else
        {
            sb.AppendLine($"Add-ons: None");
        }

        return sb.ToString().Trim();
    }

    public override void Tune(int tuneIndex, string addOn)
    {
        this.addOns.Add(addOn);
        base.Tune(tuneIndex, addOn);
    }
}