using System;
using System.Collections.Generic;
using System.Linq;

public class RoyalGuard:Soldier,IMortal
{
    public RoyalGuard(string name): base(name)
    {
    }

    public override void KingUnerAttack(Object sender, EventArgs e)
    {
        Console.WriteLine($"Royal Guard {this.Name} is defending!");
    }
}
