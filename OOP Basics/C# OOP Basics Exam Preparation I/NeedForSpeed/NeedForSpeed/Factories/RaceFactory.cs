using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RaceFactory
{
    public Race MakeRace(string type, int length, string route, int prizePool)
    {
        //o	The race type will be either “Casual”, “Drag” or “Drift”.
        if (type == "Casual")
        {
            return new CasualRace(length, route, prizePool);
        }
        else if (type == "Drag")
        {
            return new DragRace(length, route, prizePool);
        }
        else if (type == "Drift")
        {
            return new DriftRace(length, route, prizePool);
        }

        throw new ArgumentException("MakeRace: invalid race type");
    }
}
