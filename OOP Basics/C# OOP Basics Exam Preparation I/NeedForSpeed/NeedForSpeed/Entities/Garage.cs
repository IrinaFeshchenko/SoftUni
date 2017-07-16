using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Garage
{
    //o	Has parkedCars (Collection of Cars).
    private Dictionary<int,Car> parkedCars;

    public Garage()
    {
        this.parkedCars = new Dictionary<int, Car>();
    }

    public Dictionary<int, Car> ParkedCars
    {
        get { return parkedCars; }
    }

    public bool ContainsCar(int id)
    {
        if (this.parkedCars.Any(c=>c.Key==id))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public Car GetCar(int id)
    {
        if (this.parkedCars.ContainsKey(id))
        {
            return this.parkedCars[id];
        }
        return null;
    }
    public void Park(int id,Car car)
    {
        this.parkedCars.Add(id,car);
    }

    public void Unpark(int id)
    {
        this.parkedCars.Remove(id);
    }

    public void TuneCars(int tuneIndex, string addOn)
    {
        foreach (var car in parkedCars.Select(c=>c.Value))
        {
            car.Tune(tuneIndex, addOn);
        }
    }
}
