using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Garage
{
    //todo: modify parked cars ?

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

    public void Park(int id,Car car)
    {
        this.parkedCars.Add(id,car);
    }

    public void Unpark(int id)
    {
        this.parkedCars.Remove(id);
    }
}
