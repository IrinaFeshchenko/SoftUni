using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CarManager
{
    //todo: implement the methods; add ctor; initialise collections

    private Dictionary<int, Car> registeredCars;
    private Dictionary<int, Race> races;
    private Garage garage;
    private CarFactory carFactory;
    private RaceFactory raceFactory;

    public CarManager()
    {
        this.registeredCars = new Dictionary<int, Car>();
        this.races = new Dictionary<int, Race>();
        this.garage = new Garage();
        this.carFactory = new CarFactory();
        this.raceFactory = new RaceFactory();
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
        if (registeredCars.ContainsKey(id))
        {
            return this.registeredCars[id].ToString();
        }

        var parkedCar = garage.GetCar(id);

        if (parkedCar != null)
        {
            return parkedCar.ToString();
        }

        foreach (var race in races)
        {
            foreach (var car in race.Value.Participants)
            {
                if (car.Key == id)
                {
                    return car.Value.ToString();
                }
            }
        }
        return null;
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
        if (this.registeredCars.ContainsKey(carId))
        {
            this.races[raceId].AddParticipant(carId, this.registeredCars[carId]);
        }
    }

    //•	string Start(int id)
    public string Start(int id)
    {
        //•	start {raceId}
        //o	INITIATES the race with the given id. 
        //o	RETURNS detailed information about the race result.

        string result = string.Empty;

        if (this.races[id].Participants.Any())
        {
            var currentRace = this.races[id];
            this.races.Remove(id);
            currentRace.Start();
            result = currentRace.ToString();
        }
        else
        {
            result = "Cannot start the race with zero participants.";
        }

        return result;
    }

    //•	void Park(int id)
    public void Park(int id)
    {
        if (registeredCars.ContainsKey(id))
        {
            garage.Park(id, registeredCars[id]);
            registeredCars.Remove(id);
        }
    }

    //•	void Unpark(int id)
    public void Unpark(int id)
    {
        if (this.garage.ContainsCar(id))
        {
            registeredCars.Add(id, garage.GetCar(id));
            garage.Unpark(id);
        }
    }

    //•	void Tune(int tuneIndex, string addOn)
    public void Tune(int tuneIndex, string addOn)
    {
        this.garage.TuneCars(tuneIndex, addOn);
    }
}
