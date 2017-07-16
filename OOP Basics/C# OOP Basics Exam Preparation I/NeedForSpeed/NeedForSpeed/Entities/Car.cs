using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Car
{
    // brand(string), 
    private string brand;
    //a model(string), 
    private string model;
    //an yearOfProduction(int),
    private int yearOfProduction;
    //horsepower(int), 
    private int horsepower;
    //acceleration(int), 
    private int acceleration;
    //suspension(int), 
    private int suspension;
    //and durability(int).
    private int durability;

    public Car(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    {
        this.Brand = brand;
        this.Model = model;
        this.YearOfProduction = yearOfProduction;
        this.Horsepower = horsepower;
        this.Acceleration = acceleration;
        this.Suspension = suspension;
        this.Durability = durability;
    }

    public string Brand
    {
        get { return brand; }
        set { brand = value; }
    }

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    public int YearOfProduction
    {
        get { return yearOfProduction; }
        set { yearOfProduction = value; }
    }

    public int Horsepower
    {
        get { return horsepower; }
        set { horsepower = value; }
    }

    public int Acceleration
    {
        get { return acceleration; }
        set { acceleration = value; }
    }

    public int Suspension
    {
        get { return suspension; }
        set { suspension = value; }
    }

    public int Durability
    {
        get { return durability; }
        set { durability = value; }
    }

    public override string ToString()
    {
        //o   “{ brand} { model} { yearOfProduction}
        //o    { horsepower} HP, 100 m / h in { acceleration} s
        //o    { suspension} Suspension force, { durability} Durability”
        //o If the car is a PerformanceCar, you must print “Add - ons: { add - ons}”, on the last line – each add-on separated by a comma and a space “, “. 
        //  In case there are NO add-ons, print “None”.
        //o If the car is a ShowCar, you must print “{ stars} *”, on the last line.

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.Brand} {this.Model} {this.YearOfProduction}");
        sb.AppendLine($"{this.Horsepower}  HP, 100 m/h in {this.Acceleration} s");
        sb.AppendLine($"{ this.Suspension} Suspension force, { this.Durability} Durability");

        return sb.ToString();
    }

    public virtual void Tune(int tuneIndex, string addOn)
    {
        this.horsepower += tuneIndex;
        this.suspension += tuneIndex / 2;       
    }

    public int GetOveralPerformance()
    {
        return GetEnginePerformance() + GetSuspensionPerformance();
    }

    public int GetEnginePerformance()
    {
        return this.horsepower / this.acceleration;
    }

    public int GetSuspensionPerformance()
    {
        return this.Suspension + this.Durability;
    }
}
