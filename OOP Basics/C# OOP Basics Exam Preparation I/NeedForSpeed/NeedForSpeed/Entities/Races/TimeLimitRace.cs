using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class TimeLimitRace : Race
{
    public TimeLimitRace(int length, string route, int prizePool) : base(length, route, prizePool)
    {
    }

    public override void GetRaceResult()
    {
        throw new NotImplementedException();
    }

    public override void Start()
    {
        throw new NotImplementedException();
    }
}
