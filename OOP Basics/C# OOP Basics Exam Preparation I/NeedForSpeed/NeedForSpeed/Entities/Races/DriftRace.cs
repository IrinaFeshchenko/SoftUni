using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DriftRace : Race
{
    public DriftRace(int length, string route, int prizePool) 
        : base(length, route, prizePool)
    {
    }

    public override void Start()
    {
        throw new NotImplementedException();
    }
}
