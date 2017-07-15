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
    private List<Car> participants;

    public Race(int length, string route, int prizePool)
    {
        this.Length = length;
        this.Route = route;
        this.PrizePool = prizePool;
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

    public IReadOnlyList<Car> Participants
    {
        get { return participants.AsReadOnly(); }
    }

    public void AddParticipant(Car participant)
    {
        this.participants.Add(participant);
    }

    public abstract void Start();
}
