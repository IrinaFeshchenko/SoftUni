using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CarFactory
{
    public Car MakeCar(string type, string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    {
        if (type == "Performance")
        {
            return new PerformanceCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
        }
        else if (type== "Show")
        {
            return new ShowCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
        }
        else
        {
            // todo: to trow exception ?
            throw new ArgumentException("CarFactory: Invalid car type");
        }
    }
}
