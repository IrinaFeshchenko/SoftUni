using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CarManager
{
    //todo: implement the methods; add ctor; initialise collections

    private Dictionary<int, Car> registeredCars;
    private Dictionary<int, Race> races;
    private Dictionary<int, Car> parkedCars;
    private CarFactory carFactory;
    private RaceFactory raceFactory;

    public CarManager(CarFactory carFactory, RaceFactory raceFactory)
    {
        this.registeredCars = new Dictionary<int, Car>();
        this.races = new Dictionary<int, Race>();
        this.carFactory = carFactory;
        this.raceFactory = raceFactory;
    }

    //•	void Register(int id, string type, string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    public void Register(int id, string type, string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    {
        //register {id} {type} {brand} {model} {year} {horsepower} {acceleration} {suspension} {durability}
        //o	REGISTERS a car of the given type, with the given id, and the given stats.
        //o The car type will be either “Performance” or “Show”.

        var car = carFactory.MakeCar(type, brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
        if (car != null)
        {
            this.registeredCars.Add(id, car);
        }
        else
        {
            throw new ArgumentException("Register: car is null");
        }
    }

    //•	string Check(int id)
    public string Check(int id)
    {
        //•	check {id}
        //o CHECKS details about the car with the given id.
        //o RETURNS a string representation of the car.
        if (registeredCars[id] != null)
        {
            return this.registeredCars[id].ToString();
        }
        else
        {
            throw new ArgumentException("Check: car id not found");
        }
    }

    //•	void Open(int id, string type, int length, string route, int prizePool)
    public void Open(int id, string type, int length, string route, int prizePool)
    {
        //open {id} {type} {length} {route} {prizePool}
        //OPENS a race of the given type, with the given id, and stats.
        //The race type will be either “Casual”, “Drag” or “Drift”.
        var raceFactory = new RaceFactory();
        var race = raceFactory.MakeRace(type, length, route, prizePool);

        if (race != null)
        {
            this.races.Add(id, race);
        }
        else
        {
            throw new ArgumentException("Open: race is null");
        }
    }

    //•	void Participate(int carId, int raceId)
    public void Participate(int carId, int raceId)
    {
        //•	participate {carId} {raceId}
        //o	ADDS a car as a participant in the given race.
        //o	Once added, a car CANNOT turn down a race or be REMOVED from it.
        if (!this.races.ContainsKey(raceId))
        {
            throw new ArgumentException("invalid raceID");
        }

        if (!this.registeredCars.ContainsKey(carId))
        {
            throw new ArgumentException("invalid carId");
        }

        this.races[raceId].AddParticipant(this.registeredCars[carId]);
        //todo: romove car or check if car is in race garage etc.?
        registeredCars.Remove(carId);
    }

    //•	string Start(int id)
    public string Start(int id)
    {
        //•	start {raceId}
        //o	INITIATES the race with the given id. 
        //o	RETURNS detailed information about the race result.

        string result = string.Empty;
        if (!this.races.ContainsKey(id))
        {
            throw new ArgumentException("invalid start race ID");
        }

        this.races[id].Start();
        return result;
    }

    //•	void Park(int id)
    public void Park(int id)
    {
        if (registeredCars.ContainsKey(id))
        {
            parkedCars.Add(id, registeredCars[id]);
            registeredCars.Remove(id);
        }
    }

    //•	void Unpark(int id)
    public void Unpark(int id)
    {
        this.ga
    }

    //•	void Tune(int tuneIndex, string addOn)
    public void Tune(int tuneIndex, string addOn)
    {
        
    }
}
