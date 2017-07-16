using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Race
{
    //length(int), 
    private int length;
    //route(string), 
    private string route;
    //a prizePool(int), 
    private int prizePool;
    //and participants(Collection of Cars)
    private Dictionary<int,Car> participants;
    protected List<Car> winners;

    public Race(int length, string route, int prizePool)
    {
        this.Length = length;
        this.Route = route;
        this.PrizePool = prizePool;
        this.participants = new Dictionary<int, Car>();
    }

    public int Length
    {
        get { return length; }
        set { length = value; }
    }

    public string Route
    {
        get { return route; }
        set { route = value; }
    }

    public int PrizePool
    {
        get { return prizePool; }
        set { prizePool = value; }
    }

    public Dictionary<int,Car> Participants
    {
        get { return this.participants; }
    }

    public int GetPrize(int place)
    {
        if (place == 1)
        {
            return this.PrizePool / 100 * 50;
        }
        else if (place == 2)
        {
            return this.PrizePool / 100 * 30;
        }
        else if (place == 3)
        {
            return this.PrizePool / 100 * 20;
        }

        throw new ArgumentException("Invalid Place");
    }
    public void AddParticipant(int id,Car participant)
    {
        this.participants.Add(id,participant);
    }

    public abstract void Start();

    public override string ToString()
    {
        return $"{this.Route} - {this.Length}";
    }

    public abstract void GetRaceResult();
}
